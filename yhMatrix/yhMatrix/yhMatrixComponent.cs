﻿using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Rhino.Geometry;


// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace yhMatrix
{
    public class yhMatrixComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public yhMatrixComponent()
          : base("yhMatrix", "yhMatrix",
              "CreateMatrix",
              "yhMatrix", "CreateMatrix")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("NumRow", "NumRow", "NumRow", GH_ParamAccess.item);
            pManager.AddIntegerParameter("NumCol", "NumCol", "NumCol", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("RandomMatrix_List", "RandomMatrix_List", "RandomMatrix_List", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int iNumRow = new int();
            int iNumCol = new int();

            DA.GetData(0, ref iNumRow);
            DA.GetData(1, ref iNumCol);

            double[,] RandomMatrix_A = Accord.Math.Matrix.Random(iNumRow, iNumCol);
            double[] Vector_B = Accord.Math.Matrix.Reshape(RandomMatrix_A);
            List<double> List_C = Vector_B.ToList();
            DA.SetDataList(0, List_C);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("53aec2c4-4fb0-4797-b355-8bce41e98d14"); }
        }
    }
}
