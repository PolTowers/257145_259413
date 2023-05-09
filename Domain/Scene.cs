﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Scene : IComparable<Scene>
    {
        private List<PositionedModel> _positionedModels;

        public DateTime lastModified;
        public DateTime lastRendered;
        public DateTime created;

        public string name { get; set; }
        public int FieldOfVision { get; set; }

        public Scene()
        {
            this._positionedModels = new List<PositionedModel>();
            this.FieldOfVision = 30;
            this.created = DateTime.Now;
            this.lastModified = this.created;

        }

        public Scene(string name)
        {
            this.name = name;
            this._positionedModels = new List<PositionedModel>();
            this.FieldOfVision = 30;
            this.created = DateTime.Now;
        }

        public List<PositionedModel> GetPositionedModels()
        {
            return this._positionedModels;
        }



        public bool VerifyName(string name)
        {


            if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
            {
                return false;
            }

            return true;




        }

        public bool VerifyDate(DateTime date)
        {
            DateTime dateNow = DateTime.Now;

            if (DateTime.Compare(dateNow, date) > 0)
            {

                return true;
            }

            return false;
        }

        public bool VerifyPositionedModels()
        {
            return _positionedModels.Count >= 0;
        }

        public void addPositionedModel(PositionedModel positionedModel)
        {
            _positionedModels.Add(positionedModel);
            lastModified = DateTime.Now;
        }

        public void deletePositionedModel(int v)
        {
            _positionedModels.RemoveAt(v);
            lastModified = DateTime.Now;
        }

        public void Render()
        {
            lastRendered = DateTime.Now;

        }

        public bool VerifyCoordinate(float x, float y, float z)
        {


            return VerifyCoordinateValuesLens(x) && VerifyCoordinateValuesLens(y) && VerifyCoordinateValuesLens(z);


        }

        public bool ModelIsPositioned(Model model)
        {
            foreach (PositionedModel positionedModel in _positionedModels)
            {
                if (positionedModel.model == model)
                {
                    return true;
                }
            }
            return false;
        }
        //REFACTORING
        public bool VerifyCoordinateValuesLens(Object coordinate) 
        { 
            return coordinate.GetType() == typeof(float);
        }
	
		public bool VerifyFoV(int fov)
        {
            return fov >= 1 && fov <=160;
        }

        public int CompareTo(Scene scene)
        {
            if (scene.lastModified < this.lastModified)
            {
				return -1;
			}
			else if (scene.lastModified > this.lastModified)
			{
				
				return 1;
			}
            else
            {
                return 0;
            }
            

        }


		public void DeletePositionedModel(PositionedModel positionedModel)
		{
			this._positionedModels.Remove(positionedModel);
		}



	}
}

