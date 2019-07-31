using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Spiral : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Spiral class.
        /// </summary>
        public Spiral()
          : base("Spiral Curve Plots", "Spiral Curve", "A series of closed curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Anti Clothoid", "Archimedean", "Cochleoid", "Coth", "Fermat", "Hyperbolic", "Lituus", "Logarithmic", "Reciprocal", "TanH" };
            inputs = new int[] { 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 };
            SetInputs();
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary|GH_Exposure.obscure; }
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

            List<double> v = GetValues(DA);

            switch (entries[index])
            {
                case "Anti Clothoid":
                    pt = new Geodex.Curves.Spiral.AntiClothoid(t).Location;
                    break;
                case "Cochleoid":
                    pt = new Geodex.Curves.Spiral.Cochleoid(t).Location;
                    break;
                case "Coth":
                    pt = new Geodex.Curves.Spiral.Coth(t).Location;
                    break;
                case "Fermat":
                    pt = new Geodex.Curves.Spiral.Fermat(t).Location;
                    break;
                case "Hyperbolic":
                    pt = new Geodex.Curves.Spiral.Hyperbolic(t).Location;
                    break;
                case "Lituus":
                    pt = new Geodex.Curves.Spiral.Lituus(t).Location;
                    break;
                case "Logarithmic":
                    pt = new Geodex.Curves.Spiral.Logarithmic(t).Location;
                    break;
                case "Reciprocal":
                    pt = new Geodex.Curves.Spiral.Reciprocal(t).Location;
                    break;
                case "TanH":
                    pt = new Geodex.Curves.Spiral.TanH(t).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Spiral.Archimedean(t).Location;
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
                return Properties.Resources.Geodex_Curves_Spiral;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("0ec87867-45db-4b93-8f1c-5da3b494839f"); }
        }
    }
}