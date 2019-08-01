using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Surfaces
{
    public class Open : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Open class.
        /// </summary>
        public Open()
          : base("Open Surface Plots", "Open", "A series of surface equations", "Vector", "Plots")
        {
            entries = new string[] { "Coil", "Crate", "Dini", "Enneper A", "Enneper B", "Enneper C", "Gaudi", "Guimards", "Helicoid", "Helicoid Developable", "Helicoid Minimal", "Hyperbolic Paraboloid A", "Hyperbolic Paraboloid B", "Hyperbolic Paraboloid C", "Monkey A", "Monkey B", "Shell" };
            inputs = new int[] { 3,2,1,0,0,1,2,3,1,2,1,3,3,1,1,1,5 };
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
            pManager.AddVectorParameter("2d Vector", "UV", "A unitized vector most commonly between [0-1], [0,2], and [-1,1]. Z will be ignored", GH_ParamAccess.item, new Vector3d(0.5,0.5,0));
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

                case "Coil":
                    pt = new Geodex.Surfaces.Open.Coil(uv,v[0],v[1],v[2]).Location;
                    break;
                case "Crate":
                    pt = new Geodex.Surfaces.Open.Crate(uv,v[0],v[1]).Location;
                    break;
                case "Dini":
                    pt = new Geodex.Surfaces.Open.Dini(uv,v[0]).Location;
                    break;
                case "Enneper B":
                    pt = new Geodex.Surfaces.Open.Enneper_B(uv).Location;
                    break;
                case "Enneper C":
                    pt = new Geodex.Surfaces.Open.Enneper_C(uv,v[0]).Location;
                    break;
                case "Gaudi":
                    pt = new Geodex.Surfaces.Open.Gaudi(uv,v[0],v[1]).Location;
                    break;
                case "Guimards":
                    pt = new Geodex.Surfaces.Open.Guimards(uv,v[0],v[1],v[2]).Location;
                    break;
                case "Helicoid":
                    pt = new Geodex.Surfaces.Open.Helicoid(uv,v[0]).Location;
                    break;
                case "Helicoid Developable":
                    pt = new Geodex.Surfaces.Open.HelicoidDevelopable(uv,v[0],v[1]).Location;
                    break;
                case "Helicoid Minimal":
                    pt = new Geodex.Surfaces.Open.HelicoidMinimal(uv,v[0]).Location;
                    break;
                case "Hyperbolic Paraboloid A":
                    pt = new Geodex.Surfaces.Open.HyperbolicParaboloid_A(uv,v[0],v[1],v[2]).Location;
            break;
                case "Hyperbolic Paraboloid B":
                    pt = new Geodex.Surfaces.Open.HyperbolicParaboloid_B(uv,v[0],v[1],v[2]).Location;
            break;
                case "Hyperbolic Paraboloid C":
                    pt = new Geodex.Surfaces.Open.HyperbolicParaboloid_C(uv,v[0]).Location;
            break;
                case "Monkey A":
                    pt = new Geodex.Surfaces.Open.Monkey_A(uv,v[0]).Location;
            break;
                case "Monkey B":
                    pt = new Geodex.Surfaces.Open.Monkey_B(uv,v[0]).Location;
            break;
                case "Shell":
                    pt = new Geodex.Surfaces.Open.Shell(uv,v[0],v[1],v[2],v[3],v[4]).Location;
            break;
            default:
                    pt = new Geodex.Surfaces.Open.Enneper_A(uv).Location;
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
                return Properties.Resources.Geodex_Surface_Open;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("34883aa9-391e-421a-a882-728ab911fb76"); }
        }
    }
}