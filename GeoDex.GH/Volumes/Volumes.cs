using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using System.Linq;

namespace Geodex.GH.Volumes
{
    public class Volumes : GH_Component
    {
        public int selectedIndex = 0;
        private string[] entries = { "Alain", "Besace_A", "Besace_B", "Bifolium", "Biquartic", "BoothsLemniscate", "BoothsOvals", "Cassini", "Circle", "Ellipse", "Folium", "FreethNephroid", "Limacon", "Lissajous", "Plateau", "SuperEllipse", "Teardrop" };
        
        public List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

        /// <summary>
        /// Initializes a new instance of the Volumes class.
        /// </summary>
        public Volumes()
          : base("Volume Plots", "Volumes", "A Series of volume shell equations", "Vector", "Plots")
        {
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
            pManager.AddTextParameter("Test", "T", "---", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
                Vector3d uv = new Vector3d();
                DA.GetData(0, ref uv);


                DA.SetData(0, selectedIndex);
            }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {

            base.AppendAdditionalMenuItems(menu);
            Menu_AppendSeparator(menu);

            for (int i = 0; i < entries.Count(); i++)
            {
                ToolStripMenuItem item = Menu_AppendItem(menu, i.ToString(), ModeE, true, selectedIndex == i);
                item.Click -= (o, e) => { SetObject(o, e, menu); };
                item.Click += (o, e) => { SetObject(o, e, menu); };
                
            }
        }
        
        private void SetObject(Object sender, EventArgs e, ToolStripDropDown menu)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            selectedIndex = menu.Items.IndexOf(item)-4;

            ExpireSolution(true);
        }

        private void ModeE(Object sender, EventArgs e)//Additive
        {
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