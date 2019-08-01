using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Geodex.GH.Surfaces
{
    public class Intersecting : GeodexBase
    {
        /// <summary>
        /// Initializes a new instance of the Intersecting class.
        /// </summary>
        public Intersecting()
          : base("Intersecting Surface Plots", "Intersecting", "A series of surface equations", "Vector", "Plots")
        {

            entries = new string[] { "Bohemian Dome", "Boy", "Cartan", "Conoid", "CrossCap A", "CrossCap B", "Pear", "Roman To Boy", "Roman A", "Roman B", "Sine", "Whitney" };
            inputs = new int[] { 2, 0, 0, 2, 0, 0, 2, 1, 0, 0, 0, 0 };
            SetInputs();
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.secondary | GH_Exposure.obscure; }
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
                case "Bohemian Dome":
                    pt = new Geodex.Surfaces.Intersecting.BohemianDome(uv, v[0], v[1]).Location;
                    break;
                case "Boy":
                    pt = new Geodex.Surfaces.Intersecting.Boy(uv).Location;
                    break;
                case "Cartan":
                    pt = new Geodex.Surfaces.Intersecting.Cartan(uv).Location;
                    break;
                case "Conoid":
                    pt = new Geodex.Surfaces.Intersecting.Conoid(uv,v[0],v[1]).Location;
                    break;
                case "CrossCap A":
                    pt = new Geodex.Surfaces.Intersecting.CrossCap_A(uv).Location;
                    break;
                case "CrossCap B":
                    pt = new Geodex.Surfaces.Intersecting.CrossCap_B(uv).Location;
                    break;
                case "Pear":
                    pt = new Geodex.Surfaces.Intersecting.Pear(uv,v[0],v[1]).Location;
                    break;
                case "Roman To Boy":
                    pt = new Geodex.Surfaces.Intersecting.RomanToBoy(uv,v[0]).Location;
                    break;
                case "Roman A":
                    pt = new Geodex.Surfaces.Intersecting.Roman_A(uv).Location;
                    break;
                case "Roman B":
                    pt = new Geodex.Surfaces.Intersecting.Roman_B(uv).Location;
                    break;
                case "Sine":
                    pt = new Geodex.Surfaces.Intersecting.Sine(uv).Location;
                    break;
                default:
                    pt = new Geodex.Surfaces.Intersecting.Whitney(uv).Location;
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
                return Properties.Resources.Geodex_Surface_Intersect;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("f23b6758-1707-4a7a-a41f-8d6e4c90f821"); }
        }
    }
}