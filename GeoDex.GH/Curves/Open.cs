using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Open : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Open class.
        /// </summary>
        public Open()
          : base("Open Curve Plots", "Open Curve", "A series of closed curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Agnesi", "Catenary Equal Strength", "Cissoid", "Frequency", "Logarithmic", "Parabola", "Right Strophoid", "Serpentine", "Sluze Cubic", "Tractrix", "Trisectrix" };
            inputs = new int[] { 2,1,1,0,2,1,1,2,2,0,0 };
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
                case "Agnesi":
                    pt = new Geodex.Curves.Open.Agnesi(t, v[0], v[1]).Location;
                    break;
                case "Catenary Equal Strength":
                    pt = new Geodex.Curves.Open.CatenaryEqualStrength(t,v[0]).Location;
                    break;
                case "Cissoid":
                    pt = new Geodex.Curves.Open.Cissoid(t, v[0]).Location;
                    break;
                case "Frequency":
                    pt = new Geodex.Curves.Open.Frequency(t).Location;
                    break;
                case "Logarithmic":
                    pt = new Geodex.Curves.Open.Logarithmic(t, v[0], v[1]).Location;
                    break;
                case "Parabola":
                    pt = new Geodex.Curves.Open.Parabola(t, v[0]).Location;
                    break;
                case "Right Strophoid":
                    pt = new Geodex.Curves.Open.RightStrophoid(t, v[0]).Location;
                    break;
                case "Serpentine":
                    pt = new Geodex.Curves.Open.Serpentine(t, v[0], v[1]).Location;
                    break;
                case "Sluze Cubic":
                    pt = new Geodex.Curves.Open.SluzeCubic(t, v[0], v[1]).Location;
                    break;
                case "Tractrix":
                    pt = new Geodex.Curves.Open.Tractrix(t).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Open.Trisectrix(t).Location;
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
                return Properties.Resources.Geodex_Curves_Open;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("655fb808-37eb-4fac-a5a8-76180e3ba744"); }
        }
    }
}