using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Periodic : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Periodic class.
        /// </summary>
        public Periodic()
          : base("Periodic Curve Plots", "Periodic Curve", "A series of closed curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Abdank", "Cosine", "Cycloid", "Sine", "Trochoid" };
            inputs = new int[] { 1,0,0,0,2 };
            SetInputs();
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
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
                case "Abdank":
                    pt = new Geodex.Curves.Periodic.Abdank(t, v[0]).Location;
                    break;
                case "Cosine":
                    pt = new Geodex.Curves.Periodic.Cosine(t).Location;
                    break;                                  
                case "Cycloid":                             
                    pt = new Geodex.Curves.Periodic.Cycloid(t).Location;
                    break;                                  
                case "Trochoid":                            
                    pt = new Geodex.Curves.Periodic.Trochoid(t,v[0],v[1]).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Periodic.Sine(t).Location;
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
                return Properties.Resources.Geodex_Curves_Periodic;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5ba5de58-13d5-41d0-9cb6-b417c7becfe2"); }
        }
    }
}