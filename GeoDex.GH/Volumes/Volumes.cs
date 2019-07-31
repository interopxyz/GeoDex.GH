using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using System.Linq;

namespace Geodex.GH.Volumes
{
    public class Volumes : GeodexBase
    {
        
        /// <summary>
        /// Initializes a new instance of the Volumes class.
        /// </summary>
        public Volumes()
          : base("Volume Plots", "Volumes", "A Series of volume shell equations", "Vector", "Plots")
        {
            entries = new string[]{ "Astroidal Ellipsoid", "Conocuneus", "Ellipsoid", "Sphere", "Superformula", "Torus", "Torus Ellipse"};
            inputs = new int[] { 0,4,3,1,12,2,3 };
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.tertiary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("Parameter", "V", "A scalar vector parameter where X and Y properties are most commonly between [0-1], [0,2], and [-1,1]", GH_ParamAccess.item, new Vector3d(0, 0, 0));
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "The plotted Point 3d", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
                Vector3d vc = new Vector3d();
                DA.GetData(0, ref vc);
            Geodex.UV uv = new UV(vc.X, vc.Y);
            Geodex.Point pt = new Point();

            List<double> v = GetValues(DA);

            switch (entries[index])
            {
                case "AstroidalEllipsoid":
                    pt = new Geodex.Volumes.AstroidalEllipsoid(uv).Location;
                    break;
                case "Conocuneus":
                    pt = new Geodex.Volumes.Conocuneus(uv,v[0],v[1],v[2],v[3]).Location;
                    break;
                case "Ellipsoid":
                    pt = new Geodex.Volumes.Ellipsoid(uv, v[0], v[1], v[2]).Location;
                    break;
                case "Superformula":
                    pt = new Geodex.Volumes.Superformula(uv).Location;
                    break;
                case "Torus":
                    pt = new Geodex.Volumes.Torus(uv).Location;
                    break;
                case "TorusEllipse":
                    pt = new Geodex.Volumes.TorusEllipse(uv).Location;
                    break;
                default:
                    pt = new Geodex.Volumes.Sphere(uv).Location;
                    break;
            }

                DA.SetData(0, new Point3d(pt.X,pt.Y,pt.Z));
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
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("c8c1ca8b-45f0-49f0-97ff-d0ee7ab740b7"); }
        }
    }
}