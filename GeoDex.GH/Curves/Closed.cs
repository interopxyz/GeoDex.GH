using System;
using System.Collections.Generic;
using System.Reflection;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Linq;

using Geodex;
using System.Collections;

namespace Geodex.GH.Curves
{
    public class Closed : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Closed class.
        /// </summary>
        public Closed()
          : base("Closed Curve Plots", "Closed Curve", "A series of closed curve equations", "Vector", "Plots")

        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddVectorParameter("Parameter", "T", "A scalar number parameter most commonly between [0-1], [0,2], and [-1,1]", GH_ParamAccess.item, new Vector3d(0, 0, 0));
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Test", "T", "---", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            
            DA.SetDataList(0, GetAllClasses("Geodex.Curves.Open"));
        }
        public static IEnumerable GetAllClasses(string nameSpace)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (!String.IsNullOrWhiteSpace(nameSpace))
                return asm.GetTypes().Where(x => x.Namespace == nameSpace).Select(x => x.Name);
            else
                return asm.GetTypes().Select(x => x.Name);
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
            get { return new Guid("4a52e65a-c4bf-496f-892f-7e6d1d222d10"); }
        }
    }
}