using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Surfaces
{
    public class Loop : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Loop class.
        /// </summary>
        public Loop()
          : base("Loop Surface Plots", "Loop Surface", "A series of surface equations", "Vector", "Plots")
        {
            entries = new string[] { "Catenoid", "Funnel", "Gabriels", "Hyperboloid A", "Hyperboloid B", "Mobius", "Pseudosphere" };
            inputs = new int[] { 1,1,0,2,2,1,0 };
            SetInputs();
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("2d Vector", "UV", "A unitized vector most commonly between [0-1], [0,2], and [-1,1]. Z will be ignored", GH_ParamAccess.item, new Vector3d(0.5, 0.5, 0));
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
            Vector3d vc = new Vector3d();
            DA.GetData(0, ref vc);

            UV uv = new UV(vc.X, vc.Y);

            Geodex.Point pt = new Point();

            List<double> v = GetValues(DA);

            switch (entries[index])
            {

                case "Catenoid":
                    pt = new Geodex.Surfaces.Loop.Catenoid(uv,v[0]).Location;
                    break;
                case "Funnel":
                    pt = new Geodex.Surfaces.Loop.Funnel(uv,v[0]).Location;
                    break;
                case "Gabriels":
                    pt = new Geodex.Surfaces.Loop.Gabriels(uv).Location;
                    break;
                case "Hyperboloid A":
                    pt = new Geodex.Surfaces.Loop.Hyperboloid_A(uv,v[0],v[1]).Location;
                    break;
                case "Hyperboloid B":
                    pt = new Geodex.Surfaces.Loop.Hyperboloid_B(uv, v[0], v[1]).Location;
                    break;
                case "Mobius":
                    pt = new Geodex.Surfaces.Loop.Mobius(uv, v[0]).Location;
                    break;
                default:
                    pt = new Geodex.Surfaces.Loop.Pseudosphere(uv).Location;
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
                return Properties.Resources.Geodex_Surface_Loop;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("9c98de7e-98f5-4bdb-afee-8ac80e26a666"); }
        }
    }
}