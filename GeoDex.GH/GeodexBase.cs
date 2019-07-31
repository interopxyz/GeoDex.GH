using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using System.Linq;
using Grasshopper.Kernel.Parameters;
using GH_IO.Serialization;

namespace Geodex.GH
{
    public class GeodexBase : GH_Component
    {

        protected int index = 0;
        protected string[] entries = { "None" };
        protected int[] inputs = { 0 };
        private int offset = 0;

        /// <summary>
        /// Initializes a new instance of the GeodexBase class.
        /// </summary>
        public GeodexBase()
          : base("Geodex Base", "Geodex Base", "---", "Vector", "Plots")
        {
            SetInputs();
        }

        public GeodexBase(string name, string nickname, string description, string category, string subCategory)
  : base(name, nickname, description, category, subCategory)
        {
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.hidden; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }

        protected List<double> GetValues(IGH_DataAccess DA)
        {
            List<double> values = new List<double>();
            for(int i=0;i<inputs[index];i++)
            {
                double val = 1.0;
                DA.GetData(i + 1, ref val);
                values.Add(val);
            }
            return values;
        }

        #region menu updates

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);
            Menu_AppendSeparator(menu);
            offset = menu.Items.Count;
            for (int i = 0; i < entries.Count(); i++)
            {
                ToolStripMenuItem item = Menu_AppendItem(menu, entries[i], UnusedEvent, true, index == i);
                item.Click -= (o, e) => { SetObject(o, e, menu); };
                item.Click += (o, e) => { SetObject(o, e, menu); };
            }
        }

        private void SetObject(Object sender, EventArgs e, ToolStripDropDown menu)
        {

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            index = menu.Items.IndexOf(item) - offset;

            SetInputs();
            ExpireSolution(true);
        }

        private void UnusedEvent(Object sender, EventArgs e)//Additive
        {
        }

        #endregion

        #region input changes

        protected void SetInputs()
        {
            Message = entries[index];

            ClearInputs(1+inputs[index]);

            for(int i = 0;i<inputs[index];i++)
            {
                paramNumber(i+1, "Equation Input", ((char)(i + 97)).ToString().ToUpper(), "---", 1.0);
            }

            Params.OnParametersChanged();
        }

        private void ClearInputs(int clearFrom = 0)
        {
            int j = Params.Input.Count;

            for (int i = clearFrom; i < j; i++)
            {
                Params.Input[Params.Input.Count - 1].RemoveAllSources();
                Params.Input[Params.Input.Count - 1].ClearData();
                Params.UnregisterInputParameter(Params.Input[Params.Input.Count - 1]);
            }

            Params.OnParametersChanged();

        }

        private void SetParamProperties(int index, string name, string nickName, string description)
        {
            Params.Input[index].Name = name;
            Params.Input[index].NickName = nickName;
            Params.Input[index].Description = description;
            Params.Input[index].Access = GH_ParamAccess.item;
        }

        private void paramNumber(int index, string name, string nickName, string description, double Value)
        {
            if ((Params.Input.Count - 1) < index)
            {
                Params.RegisterInputParam(new Param_Number(), index);
                Params.OnParametersChanged();
            }
            else
            {
                if (Params.Input[index].GetType() != new Param_Number().GetType())
                {
                    Params.Input[index].RemoveAllSources();
                    Params.Input[index] = new Param_Number();
                    Params.OnParametersChanged();
                }
            }

            Params.Input[index].ClearData();

            Param_Number param = (Param_Number)Params.Input[index];
            param.PersistentData.ClearData();
            param.PersistentData.Clear();
            param.SetPersistentData(Value);
            SetParamProperties(index, name, nickName, description);
        }

        #endregion

        #region serialization
        
        /// <summary>
        /// Adds to the default serialization method to save the current child status so it persists on copy/paste and save/reopen.
        /// </summary>
        public override bool Write(GH_IWriter writer)
        {
            writer.SetInt32("SelectedIndex", index);

            return base.Write(writer);
        }

        /// <summary>
        /// Adds to the default deserialization method to retrieve the saved child status so it persists on copy/paste and save/reopen.
        /// </summary>
        public override bool Read(GH_IReader reader)
        {
            index = reader.GetInt32("SelectedIndex");

            SetInputs();

            return base.Read(reader);
        }

        #endregion

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
            get { return new Guid("f5cd76ea-d26f-456b-bff8-6bbbd16adeb4"); }
        }
    }
}