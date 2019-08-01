using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Curves
{
    public class Cyclic : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Cyclic class.
        /// </summary>
        public Cyclic()
          : base("Cyclic Curve Plots", "Cyclic", "A series of curve equations", "Vector", "Plots")
        {
            entries = new string[] { "Cyclic Harmonic", "Epicycloid", "Epitrochoid", "Hypocycloid A", "Hypocycloid B", "Hypotrochoid", "Leaf", "Rhodonea", "Rose", "Superformula" };
            inputs = new int[] { 3, 2, 3, 2, 1, 2, 3, 1, 2, 6 };
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
                case "Cyclic Harmonic":
                    pt = new Geodex.Curves.Cyclic.CyclicHarmonic(t, v[0], v[1],v[2]).Location;
                    break;
                case "Epicycloid":
                    pt = new Geodex.Curves.Cyclic.Epicycloid(t, v[0], v[1]).Location;
                    break;
                case "Epitrochoid":
                    pt = new Geodex.Curves.Cyclic.Epitrochoid(t, v[0], v[1],v[2]).Location;
                    break;
                case "Hypocycloid A":
                    pt = new Geodex.Curves.Cyclic.Hypocycloid_A(t, v[0], v[1]).Location;
                    break;
                case "Hypocycloid B":
                    pt = new Geodex.Curves.Cyclic.Hypocycloid_B(t, v[0]).Location;
                    break;
                case "Hypotrochoid":
                    pt = new Geodex.Curves.Cyclic.Hypotrochoid(t, v[0], v[1]).Location;
                    break;
                case "Leaf":
                    pt = new Geodex.Curves.Cyclic.Leaf(t, v[0], v[1],v[2]).Location;
                    break;
                case "Rose":
                    pt = new Geodex.Curves.Cyclic.Rose(t, v[0], v[1]).Location;
                    break;
                case "Superformula":
                    pt = new Geodex.Curves.Cyclic.Superformula(t, v[0], v[1], v[2], v[3], v[4], v[5]).Location;
                    break;
                default:
                    pt = new Geodex.Curves.Cyclic.Rhodonea(t, v[0]).Location;
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
                return Properties.Resources.Geodex_Curves_Cyclic;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("7be4f211-35cf-4e6e-995d-4d44bea96e8d"); }
        }
    }
}