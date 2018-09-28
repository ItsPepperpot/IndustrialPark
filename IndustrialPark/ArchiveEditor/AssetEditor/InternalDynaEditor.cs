﻿using System.Windows.Forms;

namespace IndustrialPark
{
    public partial class InternalDynaEditor : Form, IInternalEditor
    {
        public InternalDynaEditor(AssetDYNA asset, ArchiveEditorFunctions archive)
        {
            InitializeComponent();
            TopMost = true;

            this.asset = asset;
            this.archive = archive;

            propertyGridAsset.SelectedObject = asset;
            propertyGridDynaType.SelectedObject = asset.DynaBase;
            labelAssetName.Text = $"[{asset.AHDR.assetType.ToString()}] {asset.ToString()}";
        }

        private void InternalDynaEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            archive.CloseInternalEditor(this);
        }

        private AssetDYNA asset;
        private ArchiveEditorFunctions archive;

        public uint GetAssetID()
        {
            return asset.AHDR.assetID;
        }

        private void propertyGridAsset_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            propertyGridDynaType.SelectedObject = asset.DynaBase;
        }

        private void propertyGridDynaType_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            asset.DynaBase = (DynaBase)propertyGridDynaType.SelectedObject;
        }
    }
}
