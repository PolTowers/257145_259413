﻿using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;




namespace Engine
{
	public class Render
	{
		public Scene scene;
		public int _resolutionX;
		public int _resolutionY;
		private Vector[][] _pixels;
		private Camera _camera;
		public int samplesPerPixel;
		public int maxDepth;
		private Image<Rgba32> image;

		public Render(Scene scene)
		{
			this.scene = scene;
			this._resolutionX = 300;
			this._resolutionY = 200;
			this._pixels = new Vector[300][];
			for (int i = 0; i < 300; i++)
			{
				this._pixels[i] = new Vector[200];
			}

			Vector lookFrom = new Vector(0, 2, 0);
			Vector lookAt = new Vector(0, 2, 5);
			Vector up = new Vector(0, 1, 0);
			this._camera = new CommonCamera(lookFrom, lookAt, up, 30, (double)300 / 200);
			this.samplesPerPixel = 50;
			this.maxDepth = 20;
		}

		public Render(Scene scene, Coordinate lookFrom, Coordinate lookAt, int fov) : this(scene)
		{
			Vector lookFromVector = new Vector(lookFrom.x, lookFrom.y, lookFrom.z);
			Vector lookAtVector = new Vector(lookAt.x, lookAt.y, lookAt.z);
			Vector up = new Vector(0, 1, 0);
			this._camera = new CommonCamera(lookFromVector, lookAtVector, up, fov, (double)300 / 200);
		}

		public Render(Scene scene, int resolutionX, int resolutionY, int samplesPerPixel, int maxDepth) : this(scene)
		{
			this._resolutionX = resolutionX;
			this._resolutionY = resolutionY;
			this._pixels = new Vector[resolutionX][];
			for (int i = 0; i < resolutionX; i++)
			{
				this._pixels[i] = new Vector[resolutionY];
			}

			Vector lookFrom = new Vector(0, 2, 0);
			Vector lookAt = new Vector(0, 2, 5);
			Vector up = new Vector(0, 1, 0);
			this._camera = new CommonCamera(lookFrom, lookAt, up, 30, resolutionX / resolutionY);
			this.samplesPerPixel = samplesPerPixel;
			this.maxDepth = maxDepth;
		}

		public Render(Scene scene, Coordinate lookFrom, Coordinate lookAt, int fov, double aperture) : this(scene)
		{
			Vector lookFromVector = new Vector(lookFrom.x, lookFrom.y, lookFrom.z);
			Vector lookAtVector = new Vector(lookAt.x, lookAt.y, lookAt.z);
			Vector up = new Vector(0, 1, 0);
			this._camera = new AdvancedCamera(lookFromVector, lookAtVector, up, fov, (double)300 / 200, aperture);
		}

		private string RenderPPMImage(string filePath, string client)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new Exception("File does not exist");
            }
            string fileContents = System.IO.File.ReadAllText(filePath);
            string filename = Path.GetFileName(filePath);
            var data = fileContents.Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(data);

            int width, height;
            formatPPM(data, out width, out height);
            using var img = new Image<Rgba32>(width, height);
            int index = 4;
            for (int y = 0; y < height; y++)
            {
                index = writePNG(data, width, img, index, y);
            }
            this.image = img;
            string imgUrl = saveImage(client, filename, img);

            return imgUrl;
        }

        private static void formatPPM(string[] data, out int width, out int height)
        {
            if (data[0] != "P3")
            {
                throw new ArgumentException("File is not a PPM");
            }
            int.TryParse(data[1], out width);
            int.TryParse(data[2], out height);
            int.TryParse(data[3], out int maxColors);
            if (maxColors != 255)
            {
                throw new ArgumentException("MaxColors is not 255");
            }
            if (data.Length != 3 * width * height + 4)
            {
                throw new ArgumentException($"Not enough pixel data. Found: {data.Length - 4}, Expecting: {3 * width * height}, Based on width = {width} and height = {height}");
            }
        }

        private string saveImage(string client, string filename, Image<Rgba32> img)
		{

			var imagePath = Path.Combine("wwwroot", "images", client);
			var jpgPath = imagePath;

			if (!Directory.Exists(imagePath))
			{
				Directory.CreateDirectory(imagePath);
			}
			imagePath = Path.Combine(imagePath, this.scene.name + ".png");
			img.Save(imagePath, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
			jpgPath = Path.Combine(jpgPath, this.scene.name + ".jpg");

			img.Save(jpgPath, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder());
			
		
			string imgUrl = "/images/" + filename + ".png";
			return imgUrl;
		}

		public static string GetPath(string selected, string name,string scene )
		{

			string path = Path.Combine( "images", name, scene);
			
			switch (selected)
			{

				case "PNG": 
					path=Path.Combine(path+ ".png");
					break;
				case "JPG":
				   path= Path.Combine(path+ ".jpg");
					break;
				case "PPM":
					path= Path.Combine(path+ ".ppm");
				
					break;

			}

			return path;
		}

		public Image<Rgba32> GetImage()
		{

			return this.image;



		}



		private int writePNG(string[] data, int width, Image<Rgba32> img, int index, int y)
		{
			for (int x = 0; x < width; x++)
			{
				int.TryParse(data[index], out int r);
				int.TryParse(data[index + 1], out int g);
				int.TryParse(data[index + 2], out int b);
				img[x, y] = new Rgba32((byte)r, (byte)g, (byte)b);
				index += 3;
			}

			return index;
		}

		public void RenderScene(string client)
		{
			Random random = new Random();
			for (var row = this._resolutionY - 1; row >= 0; row--)
			{
				writePixel(random, row);
			}

			var imageString = "P3\n" + this._resolutionX + " " + this._resolutionY + "\n255\n";

			for (var j = 0; j < this._resolutionY; j++)
			{
				imageString = toRGB(imageString, j);
			}

			string path = Path.Combine("wwwroot","images", client);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			path = Path.Combine(path,this.scene.name + ".ppm");

			File.WriteAllText(path, imageString);
			RenderPPMImage(path, client);
		}

		private string toRGB(string imageString, int j)
		{
			for (var i = 0; i < this._resolutionX; i++)
			{
				var color = _pixels[i][j];
				imageString += color.Red() + " " + color.Green() + " " + color.Blue() + "\n";
			}

			return imageString;
		}

		private void writePixel(Random random, int row)
		{
			for (var column = 0; column < this._resolutionX; column++)
			{
				var pixelColor = new Vector(0, 0, 0);
				for (var sample = 0; sample < samplesPerPixel; sample++)
				{
					var u = (column + random.NextDouble()) / this._resolutionX;
					var v = (row + random.NextDouble()) / this._resolutionY;
					var ray = this._camera.getRay(u, v);
					pixelColor.AddTo(ShootRay(ray, this.maxDepth));
				}
				pixelColor = pixelColor.Divide(this.samplesPerPixel);
				SavePixel(row, column, pixelColor);
			}
		}

		private void SavePixel(int row, int column, Vector pixelRGB)
		{
			int posX = column;
			int posY = this._resolutionY - row - 1;
			if (posY < this._resolutionY)
			{
				this._pixels[posX][posY] = pixelRGB;
			}
			else
			{
				throw new Exception("Pixel Overflow Error");
			}
		}

		private HitRecord isModelHit(PositionedModel model, Ray ray, double tMin, double tMax)
		{
			Vector originalColor = new Vector(model.model.material.color.R, model.model.material.color.G, model.model.material.color.B).getUnit();
			Vector modelCenter = new Vector(model.position.x, model.position.y, model.position.z);
			Vector originCenter = ray.Origin.Subtract(modelCenter);
			var a = ray.Direction.Dot(ray.Direction);
			var b = originCenter.Dot(ray.Direction) * 2;
			double c = originCenter.Dot(originCenter) - Math.Pow(model.model.figure.radius, 2);
			double discriminant = (b * b) - (4 * a * c);
			if (discriminant < 0)
			{
				return null;
			}
			var t = ((-1 * b) - Math.Sqrt(discriminant)) / (2 * a);
			Vector intersectionPoint = ray.PointAt(t);
			Vector normal = intersectionPoint.Subtract(modelCenter).Divide(model.model.figure.radius);
			if (t < tMax && t > tMin)
			{
				return new HitRecord(t, intersectionPoint, normal, originalColor, model.model.material);
			}
			return null;

		}

		private Vector ShootRay(Ray ray, int depth)
		{
			HitRecord hitRecord = null;
			double tMax = Math.Pow(10, 28);
			foreach (PositionedModel model in this.scene.GetPositionedModels())
			{
				HitRecord hit = isModelHit(model, ray, 0.001, tMax);
				if (hit != null)
				{
					hitRecord = hit;
					tMax = hit.T;
				}
			}
			if (hitRecord != null)
			{
				if (depth > 0)
                {
                    return CalculateReflectionColor(ray, depth, hitRecord);
                }

                return new Vector(0, 0, 0);

			}

			Vector directionUnit = ray.Direction.getUnit();
			double posY = 0.5 * (directionUnit.Y + 1);
			Vector start = new Vector(1, 1, 1);
			Vector end = new Vector(0.5, 0.7, 1.0);
			return start.Multiply(1 - posY).Add(end.Multiply(posY));

		}

        private Vector CalculateReflectionColor(Ray ray, int depth, HitRecord hitRecord)
        {
            Ray newRay;
            if (hitRecord.Material is MetalicMaterial)
            {
                newRay = MetalicScatter(ray, hitRecord);
                if (newRay == null)
                {
                    return new Vector(0, 0, 0);
                }
            }
            else if (hitRecord.Material is LambertianoMaterial)
            {
                newRay = LambertianScatter(ray, hitRecord);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
            Vector color = ShootRay(newRay, depth - 1);
            Vector attenuation = hitRecord.Attenuation;
            return new Vector(color.X * attenuation.X,
                color.Y * attenuation.Y,
                color.Z * attenuation.Z);
        }

        private Ray LambertianScatter(Ray ray, HitRecord hitRecord)
		{
			Vector newPoint = hitRecord.Intersection
				.Add(hitRecord.Normal)
				.Add(Vector.GetRandomInUnitModel());
			Vector result = newPoint.Subtract(hitRecord.Intersection);
			return new Ray(hitRecord.Intersection, result);
		}

		private Ray MetalicScatter(Ray rayIn, HitRecord hitRecord)
		{
			Ray scatteredRay = new Ray(new Vector(0, 0, 0), new Vector(0, 0, 0));
			Vector reflected = Reflect(rayIn.Direction.getUnit(), hitRecord.Normal);
			scatteredRay.Origin = hitRecord.Intersection;
			scatteredRay.Direction = reflected.Add(
				Vector.GetRandomInUnitModel()
				.Multiply(hitRecord.Roughness));
			if (scatteredRay.Direction.Dot(hitRecord.Normal) > 0)
			{
				return scatteredRay;
			}
			return null;
		}

		private Vector Reflect(Vector vector, Vector normal)
		{
			double dotVN = vector.Dot(normal);
			return vector.Subtract(normal.Multiply(2 * dotVN));
		}

		public static void CreatePreview(Model model, string name)
        {
            Scene scene = new Scene("model_" + model.name);
            Material floorColor = new LambertianoMaterial("floor", System.Drawing.Color.White);
            Figure floor = new Figure("floor", 1000);
            Model earth = new Model("earth", floor, floorColor);
            Coordinate position = new Coordinate(0, -999, 5);
            PositionedModel positionedEarth = new PositionedModel();
            positionedEarth.model = earth;
            positionedEarth.position = position;
            scene.addPositionedModel(positionedEarth);

            position = AddTempModelToScene(model, scene);

            Render render = new Render(scene, 150, 100, 30, 20);
            render.RenderScene(name);
        }

        private static Coordinate AddTempModelToScene(Model model, Scene scene)
        {
            Coordinate position;
            Figure test = new Figure("test", 1);
            Model temp = new Model("object", test, model.material);
            position = new Coordinate(0, 2, 5);
            PositionedModel positionedTemp = new PositionedModel();
            positionedTemp.model = temp;
            positionedTemp.position = position;
            scene.addPositionedModel(positionedTemp);
            return position;
        }
    }
}