using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Fixed : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Fixed class.
        /// </summary>
        public Fixed()
          : base("Fixed Curve Plots", "Fixed Curve", "A series of closed curve equations", "Vector", "Plots")
        {

            entries = new string[] { "Asteroid", "Bicorn", "Butterfly", "Cardioid", "Cayleys Sextic", "Double Folium", "Fish", "Humbert Cubic", "Kappa", "Kiss", "Lemniscate", "Maltese Cross", "Nephroid", "Quadrifolium", "Talbot", "Tricuspoid", "Trifolium", "Watts" };
            inputs = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            SetInputs();
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary | GH_Exposure.obscure; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Parameter", "T", "A scalar number parameter most commonly between [0-1], [0,2], and [-1,1]", GH_ParamAccess.item, 0.5);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "The plotted coordinate point", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double t = 0.5;
            DA.GetData(0, ref t);

            Geodex.Point pt = new Point();

            switch (entries[index])
            {
                case "Bicorn":
                    pt = new Geodex.Curves.Fixed.Bicorn(t).Location;
                    break;
                case "Butterfly":
                    pt = new Geodex.Curves.Fixed.Butterfly(t).Location;
                    break;
                case "Cardioid":
                    pt = new Geodex.Curves.Fixed.Cardioid(t).Location;
                    break;
                case "Cayleys Sextic":
                    pt = new Geodex.Curves.Fixed.CayleysSextic(t).Location;
                    break;
                case "Double Folium":
                    pt = new Geodex.Curves.Fixed.DoubleFolium(t).Location;
                    break;
                case "Fish":
                    pt = new Geodex.Curves.Fixed.Fish(t).Location;
                    break;
                case "Humbert Cubic":
                    pt = new Geodex.Curves.Fixed.HumbertCubic(t).Location;
                    break;
                case "Kappa":
                    pt = new Geodex.Curves.Fixed.Kappa(t).Location;
                    break;
                case "Kiss":
                    pt = new Geodex.Curves.Fixed.Kiss(t).Location;
                    break;
                case "Lemniscate":
                    pt = new Geodex.Curves.Fixed.Lemniscate(t).Location;
                    break;
                case "Maltese Cross":
                    pt = new Geodex.Curves.Fixed.MalteseCross(t).Location;
                    break;
                case "Nephroid":
                    pt = new Geodex.Curves.Fixed.Nephroid(t).Location;
                    break;
                case "Quadrifolium":
                    pt = new Geodex.Curves.Fixed.Quadrifolium(t).Location;
                    break;
                case "Talbot":
                    pt = new Geodex.Curves.Fixed.Talbot(t).Location;
                    break;
                case "Tricuspoid":
                    pt = new Geodex.Curves.Fixed.Tricuspoid(t).Location;
                    break;
                case "Trifolium":
                    pt = new Geodex.Curves.Fixed.Trifolium(t).Location;
                    break;
                case "Watts":
                    pt = new Geodex.Curves.Fixed.Watts(t).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Fixed.Asteroid(t).Location;
                    break;
            }

            DA.SetData(0, new Point3d(pt.X, pt.Y, pt.Z));
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.Geodex_Curves_Fixed;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("e1172e54-ee6d-4ba1-ac0f-434429df5a7f"); }
        }
    }
}