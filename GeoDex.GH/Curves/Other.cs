using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Other : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Other class.
        /// </summary>
        public Other()
          : base("Other Curve Plots", "Other Curve", "A series of closed curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Catalan", "Conchal", "Conchoid", "Epispiral", "Hippias Quadratrix", "Hyperbola", "Kampyle", "Nodal" };
            inputs = new int[] { 1, 2, 2, 1, 1, 2, 2, 1 };
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
                case "Catalan":
                    pt = new Geodex.Curves.Other.Catalan(t, v[0]).Location;
                    break;
                case "Conchal":
                    pt = new Geodex.Curves.Other.Conchal(t, v[0], v[1]).Location;
                    break;
                case "Conchoid":
                    pt = new Geodex.Curves.Other.Conchoid(t, v[0], v[1]).Location;
                    break;
                case "Hippias Quadratrix":
                    pt = new Geodex.Curves.Other.HippiasQuadratrix(t, v[0]).Location;
                    break;
                case "Hyperbola":
                    pt = new Geodex.Curves.Other.Hyperbola(t, v[0], v[1]).Location;
                    break;
                case "Kampyle":
                    pt = new Geodex.Curves.Other.Kampyle(t, v[0], v[1]).Location;
                    break;
                case "Nodal":
                    pt = new Geodex.Curves.Other.Nodal(t, v[0]).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Other.Epispiral(t).Location;
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
                return Properties.Resources.Geodex_Curves_Other;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("fa2257f2-fe59-4703-bf4c-f4a5c138de03"); }
        }
    }
}