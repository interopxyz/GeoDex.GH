using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Spatial : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Spatial class.
        /// </summary>
        public Spatial()
          : base("Spatial Curve Plots", "Spatial", "A series of curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Archytas", "Baseball", "Basin", "Billiard Knot", "Clelies", "Helix", "Loxodrome", "Torus Asymptotic", "Torus Knot", "Vivianis" };
            inputs = new int[] { 0,2,4,3,2,0,1,2,4,0 };
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

            List<double> v = GetValues(DA);

            switch (entries[index])
            {
                case "Archytas":
                    pt = new Geodex.Curves.Spatial.Archytas(t).Location;
                    break;
                case "Baseball":
                    pt = new Geodex.Curves.Spatial.Baseball(t, v[0], v[1]).Location;
                    break;
                case "Basin":
                    pt = new Geodex.Curves.Spatial.Basin(t, v[0], v[1], v[2], v[3]).Location;
                    break;
                case "Billiard Knot":
                    pt = new Geodex.Curves.Spatial.BilliardKnot(t, v[0], v[1], v[2]).Location;
                    break;
                case "Clelies":
                    pt = new Geodex.Curves.Spatial.Clelies(t, v[0], v[1]).Location;
                    break;
                case "Helix":
                    pt = new Geodex.Curves.Spatial.Helix(t).Location;
                    break;
                case "Loxodrome":
                    pt = new Geodex.Curves.Spatial.Loxodrome(t, v[0]).Location;
                    break;
                case "Torus Asymptotic":
                    pt = new Geodex.Curves.Spatial.TorusAsymptotic(t, v[0], v[1]).Location;
                    break;
                case "Torus Knot":
                    pt = new Geodex.Curves.Spatial.TorusKnot(t, v[0], v[1], v[2], v[3]).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Spatial.Vivianis(t).Location;
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
                return Properties.Resources.Geodex_Curves_Spatial;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3b8da665-2b9d-4912-a2cf-50a0a604c061"); }
        }
    }
}