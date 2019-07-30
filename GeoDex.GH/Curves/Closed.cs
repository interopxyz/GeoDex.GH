using System;
using System.Collections.Generic;
using System.Reflection;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Linq;

using Geodex;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Geodex.GH.Curves
{
    public class Closed : GH_Component
    {
        private int selectedIndex = 0;
        private string[] entries = { "Alain", "Besace_A", "Besace_B", "Bifolium", "Biquartic", "BoothsLemniscate", "BoothsOvals", "Cassini", "Circle", "Ellipse", "Folium", "FreethNephroid", "Limacon", "Lissajous", "Plateau", "SuperEllipse", "Teardrop" };
        
        public event SelectionChanged Changed;
        public delegate void SelectionChanged(Closed sender, int prevIndex);

        public string Name { get; }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { Callback(this, new EventArgs(), value); }
        }

        private void Callback(object sender, EventArgs args, int index)
        {
            if (selectedIndex != index)
            {
                int prevIndex = selectedIndex;
                selectedIndex = index;

                Changed?.Invoke(this, prevIndex);
            }
            this.ExpireSolution(true);
        }

        public interface IMenuWatcher
        {
            string Name { get; }
            void AppendMenu(ToolStripDropDown menu);
        }

        /// <summary>
        /// Initializes a new instance of the Closed class.
        /// </summary>
        public Closed()
          : base("Closed Curve Plots", "Closed Curve", "A series of closed curve equations", "Vector", "Plots")
        {
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
            pManager.AddTextParameter("Test", "T", "---", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double t = 0.5;
            DA.GetData(0,ref t);
            

            DA.SetData(0, selectedIndex);
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {

            base.AppendAdditionalMenuItems(menu);
            Menu_AppendSeparator(menu);

            for(int i = 0;i< entries.Count();i++)
            {
                ToolStripMenuItem item = Menu_AppendItem(menu, entries[i], (s, ev) => Callback(s, ev, i),false, SelectedIndex == i);
                
            }
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



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