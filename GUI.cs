using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using AddedFormTool;

using FlatBuffers;

using static System.Windows.Forms.CheckedListBox;

using Color = AddedFormTool.Color;

namespace Additional_Form_Tool_GUI {
    public partial class GUI : Form {
        public GUI() {
            InitializeComponent();

            HairTypeComboBox.Items.AddRange(Enum.GetNames(typeof(HairIndex)));
            UltimateAttackComboBox.Items.AddRange(Enum.GetNames(typeof(UltimateAttack)));
            AuraSoundComboBox.Items.AddRange(Enum.GetNames(typeof(AuraSounds)));
            TransformationSoundComboBox.Items.AddRange(Enum.GetNames(typeof(TransformSounds)));
            CutsceneAuraComboBox.Items.AddRange(Enum.GetNames(typeof(CutsceneAuraStart)));
            AuraStartComboBox.Items.AddRange(Enum.GetNames(typeof(AuraStart)));
            AuraComboBox.Items.AddRange(Enum.GetNames(typeof(Aura)));
            KKAuraSound.Items.AddRange(Enum.GetNames(typeof(AuraSounds)));
            KKStartingAura.Items.AddRange(Enum.GetNames(typeof(AuraStart)));
            KKLoopingAura.Items.AddRange(Enum.GetNames(typeof(Aura)));
        }

        private void HairColorButton_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                HairColorButton.BackColor = cd.Color;
            }
        }

        private void EyeColorButton_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                EyeColorButton.BackColor = cd.Color;
            }
        }

        private void GUITextColorButton_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                GUITextColorButton.BackColor = cd.Color;
            }
        }

        private void KiChargeColorButton_Click(object sender, EventArgs e) {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                KiChargeColorButton.BackColor = cd.Color;
            }
        }

        private void NumberValueBox_TextChanged(object sender, EventArgs e) {
            var tb = sender as TextBox;
            List<char> validChars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-' };
            bool hasSeenPeriod = false;
            bool isNegative = false;
            List<char> keep = new List<char>();
            foreach (var tryChar in tb.Text) {
                if (validChars.Contains(tryChar)) {
                    if (tryChar == '-') {
                        if (!isNegative) {
                            isNegative = true;
                        }
                    } else if (tryChar == '.') {
                        if (!hasSeenPeriod) {
                            keep.Add(tryChar);
                            hasSeenPeriod = true;
                        }
                    } else
                        keep.Add(tryChar);
                }
            }

            var keepArray = keep.ToArray();

            if (isNegative)
                keepArray = keepArray.Prepend('-').ToArray();

            tb.Text = new string(keepArray);
        }

        private void LoadForm_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                Filter = "Transformation files (*.form)|*.form"
            };

            if (ofd.ShowDialog() == DialogResult.OK) {
                ByteBuffer bb = new ByteBuffer(File.ReadAllBytes(ofd.FileName));

                var form = Transformation.GetRootAsTransformation(bb);

                FName.Text = form.Name;
                NameAbbriviation.Text = form.NameAbbriviation;
                AuraComboBox.SelectedIndex = (int)form.Aura;
                AuraStartComboBox.SelectedIndex = (int)form.AuraStart;
                CutsceneAuraComboBox.SelectedIndex = (int)form.CutsceneAuraStart;
                TransformationSoundComboBox.SelectedIndex = Enum.GetNames(typeof(TransformSounds)).ToList().IndexOf(Enum.GetName(typeof(TransformSounds), form.TransformSounds));
                AuraSoundComboBox.SelectedIndex = Enum.GetNames(typeof(AuraSounds)).ToList().IndexOf(Enum.GetName(typeof(AuraSounds), form.AuraSounds));
                UltimateAttackComboBox.SelectedIndex = (int)form.SelectedUltimateAttack;
                MasteryLevelsToUnlockTB.Text = $"{form.MasteryLevelsToUnlock}";
                ChargeMultiTB.Text = $"{form.ChargeMultiplier}";
                StrainMultiTB.Text = $"{form.StrainMultiplier}";
                ExpCostMulti.Text = $"{form.ExpCostMultiplier}";

                AllowedCharactersCheckedListBox.SetItemChecked(0, false);
                AllowedCharactersCheckedListBox.SetItemChecked(1, false);
                AllowedCharactersCheckedListBox.SetItemChecked(2, false);

                switch (form.AllowedCharacters) {
                    case AllowedCharacters.Goku:
                        AllowedCharactersCheckedListBox.SetItemChecked(0, true);
                        break;
                    case AllowedCharacters.Vegeta:
                        AllowedCharactersCheckedListBox.SetItemChecked(1, true);
                        break;
                    case AllowedCharacters.Trunks:
                        AllowedCharactersCheckedListBox.SetItemChecked(2, true);
                        break;
                    case AllowedCharacters.GokuVegeta:
                        AllowedCharactersCheckedListBox.SetItemChecked(0, true);
                        AllowedCharactersCheckedListBox.SetItemChecked(1, true);
                        break;
                    case AllowedCharacters.GokuTrunks:
                        AllowedCharactersCheckedListBox.SetItemChecked(0, true);
                        AllowedCharactersCheckedListBox.SetItemChecked(2, true);
                        break;
                    case AllowedCharacters.VegetaTrunks:
                        AllowedCharactersCheckedListBox.SetItemChecked(1, true);
                        AllowedCharactersCheckedListBox.SetItemChecked(2, true);
                        break;
                    case AllowedCharacters.GokuVegetaTrunks:
                        AllowedCharactersCheckedListBox.SetItemChecked(0, true);
                        AllowedCharactersCheckedListBox.SetItemChecked(1, true);
                        AllowedCharactersCheckedListBox.SetItemChecked(2, true);
                        break;
                }

                KiDrainTB.Text = $"{form.KiDrain}";
                DamageTB.Text = $"{form.DamagePercentBonus}";
                ArmorTB.Text = $"{form.ArmorPercentBonus}";
                AttackSpeedTB.Text = $"{form.AttackSpeedPercentBonus}";
                MoveSpeedTB.Text = $"{form.MoveSpeedPercentBonus}";
                RegenTB.Text = $"{form.RegenPercentBonus}";

                HairColorButton.BackColor = System.Drawing.Color.FromArgb(255, form.HairColor.R, form.HairColor.G, form.HairColor.B);
                EyeColorButton.BackColor = System.Drawing.Color.FromArgb(255, form.EyeColor.R, form.EyeColor.G, form.EyeColor.B);
                GUITextColorButton.BackColor = System.Drawing.Color.FromArgb(255, form.GuiTextColor.R, form.GuiTextColor.G, form.GuiTextColor.B);
                KiChargeColorButton.BackColor = System.Drawing.Color.FromArgb(255, form.KiChargeColor.R, form.KiChargeColor.G, form.KiChargeColor.B);

                HairTypeComboBox.SelectedIndex = (int)form.HairIndex;

                ChestScaleTB.Text = $"{form.ChestScale}";
                ArmsScaleTB.Text = $"{form.ArmsScale}";
                LegsScaleTB.Text = $"{form.LegsScale}";
                DodgeChanceTB.Text = $"{form.DodgeChance}";
                TeleportOnMeleeCB.Checked = form.TeleportOnMelee;
            }
        }

        private void SaveForm_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog {
                Filter = "Transformation files (*.form)|*.form",
                FileName = $"{NameAbbriviation.Text}.form"
            };


            if (sfd.ShowDialog() == DialogResult.OK) {
                FlatBufferBuilder fbb = new FlatBufferBuilder(256);

                var name = fbb.CreateString(FName.Text);
                var abbr = fbb.CreateString(NameAbbriviation.Text);

                Transformation.StartTransformation(fbb);

                Transformation.AddName(fbb, name);
                Transformation.AddNameAbbriviation(fbb, abbr);
                Transformation.AddAura(fbb, (Aura)(byte)AuraComboBox.SelectedIndex);
                Transformation.AddAuraStart(fbb, (AuraStart)(byte)AuraStartComboBox.SelectedIndex);
                Transformation.AddCutsceneAuraStart(fbb, (CutsceneAuraStart)(byte)CutsceneAuraComboBox.SelectedIndex);
                Transformation.AddTransformSounds(fbb, TransformationSoundComboBox.SelectedIndex == 0 ? TransformSounds.UI : TransformSounds.Generic);
                AuraSounds auraSound = AuraSounds.SSJ;

                switch (AuraSoundComboBox.SelectedIndex) {
                    case 0:
                        auraSound = AuraSounds.SSJ3;
                        break;
                    case 1:
                        auraSound = AuraSounds.SSJ2;
                        break;
                    case 2:
                        auraSound = AuraSounds.SSJ;
                        break;
                    case 3:
                        auraSound = AuraSounds.SSG;
                        break;
                    case 4:
                        auraSound = AuraSounds.SSB;
                        break;
                    case 5:
                        auraSound = AuraSounds.SSR;
                        break;
                    case 6:
                        auraSound = AuraSounds.Kaioken;
                        break;
                }

                Transformation.AddAuraSounds(fbb, auraSound);
                Transformation.AddSelectedUltimateAttack(fbb, (UltimateAttack)(byte)UltimateAttackComboBox.SelectedIndex);
                Transformation.AddMasteryLevelsToUnlock(fbb, (int)float.Parse(MasteryLevelsToUnlockTB.Text));
                Transformation.AddChargeMultiplier(fbb, float.Parse(ChargeMultiTB.Text));
                Transformation.AddStrainMultiplier(fbb, float.Parse(StrainMultiTB.Text));
                Transformation.AddExpCostMultiplier(fbb, float.Parse(ExpCostMulti.Text));

                AllowedCharacters allowedCharacters = AllowedCharacters.GokuVegetaTrunks;
                CheckedIndexCollection cic = AllowedCharactersCheckedListBox.CheckedIndices;
                for (int i = 0; i < cic.Count; i++) {
                    if (i == 0) {
                        switch (cic[i]) {
                            case 0:
                                allowedCharacters = AllowedCharacters.Goku;
                                break;
                            case 1:
                                allowedCharacters = AllowedCharacters.Vegeta;
                                break;
                            case 2:
                                allowedCharacters = AllowedCharacters.Trunks;
                                break;
                        }
                    }
                    switch (cic[i]) {
                        case 0:
                            if (allowedCharacters == AllowedCharacters.Trunks)
                                allowedCharacters = AllowedCharacters.GokuTrunks;
                            if (allowedCharacters == AllowedCharacters.Vegeta)
                                allowedCharacters = AllowedCharacters.GokuVegeta;
                            break;
                        case 1:
                            if (allowedCharacters == AllowedCharacters.Trunks)
                                allowedCharacters = AllowedCharacters.VegetaTrunks;
                            if (allowedCharacters == AllowedCharacters.Goku)
                                allowedCharacters = AllowedCharacters.GokuVegeta;
                            break;
                        case 2:
                            if (allowedCharacters == AllowedCharacters.Goku)
                                allowedCharacters = AllowedCharacters.GokuTrunks;
                            if (allowedCharacters == AllowedCharacters.Vegeta)
                                allowedCharacters = AllowedCharacters.GokuVegeta;
                            break;
                    }
                    if (i == 2)
                        allowedCharacters = AllowedCharacters.GokuVegetaTrunks;
                }

                Transformation.AddAllowedCharacters(fbb, allowedCharacters);
                Transformation.AddKiDrain(fbb, float.Parse(KiDrainTB.Text));
                Transformation.AddDamagePercentBonus(fbb, float.Parse(DamageTB.Text));
                Transformation.AddArmorPercentBonus(fbb, float.Parse(ArmorTB.Text));
                Transformation.AddAttackSpeedPercentBonus(fbb, float.Parse(AttackSpeedTB.Text));
                Transformation.AddMoveSpeedPercentBonus(fbb, float.Parse(MoveSpeedTB.Text));
                Transformation.AddRegenPercentBonus(fbb, float.Parse(RegenTB.Text));
                Transformation.AddHairColor(fbb, Color.CreateColor(fbb, HairColorButton.BackColor.R, HairColorButton.BackColor.G, HairColorButton.BackColor.B));
                Transformation.AddEyeColor(fbb, Color.CreateColor(fbb, EyeColorButton.BackColor.R, EyeColorButton.BackColor.G, EyeColorButton.BackColor.B));
                Transformation.AddGuiTextColor(fbb, Color.CreateColor(fbb, GUITextColorButton.BackColor.R, GUITextColorButton.BackColor.G, GUITextColorButton.BackColor.B));
                Transformation.AddKiChargeColor(fbb, Color.CreateColor(fbb, KiChargeColorButton.BackColor.R, KiChargeColorButton.BackColor.G, KiChargeColorButton.BackColor.B));
                Transformation.AddHairIndex(fbb, (HairIndex)(byte)HairTypeComboBox.SelectedIndex);
                Transformation.AddChestScale(fbb, float.Parse(ChestScaleTB.Text));
                Transformation.AddArmsScale(fbb, float.Parse(ArmsScaleTB.Text));
                Transformation.AddLegsScale(fbb, float.Parse(LegsScaleTB.Text));
                Transformation.AddTeleportOnMelee(fbb, TeleportOnMeleeCB.Checked);
                Transformation.AddDodgeChance(fbb, float.Parse(DodgeChanceTB.Text));
                Transformation.FinishTransformationBuffer(fbb, Transformation.EndTransformation(fbb));
                using var ms = new MemoryStream(fbb.DataBuffer.Data, fbb.DataBuffer.Position, fbb.Offset);
                File.WriteAllBytes(sfd.FileName, ms.ToArray());
            }
        }

        private void KKLoad_Click(object sender, EventArgs e) {

            var ofd = new OpenFileDialog {
                Filter = "Kaioken Transformation files (*.kkf)|*.kkf"
            };

            if (ofd.ShowDialog() == DialogResult.OK) {
                ByteBuffer bb = new ByteBuffer(File.ReadAllBytes(ofd.FileName));

                var kkf = KaiokenTransformation.GetRootAsKaiokenTransformation(bb);

                KKName.Text = kkf.Name;
                KKAbbriviation.Text = kkf.NameAbbriviation;
                KKLoopingAura.SelectedIndex = (byte)kkf.Aura;
                KKStartingAura.SelectedIndex = (byte)kkf.AuraStart;
                KKAuraSound.SelectedIndex = Enum.GetNames(typeof(AuraSounds)).ToList().IndexOf(Enum.GetName(typeof(AuraSounds), kkf.AuraSounds));
                KKDamageBonus.Text = $"{kkf.DamagePercentBonus}";
                KKAttackSpeedBonus.Text = $"{kkf.AttackSpeedPercentBonus}";
                KKMoveSpeedBonus.Text = $"{kkf.MoveSpeedPercentBonus}";
                KKChargeMultiplier.Text = $"{kkf.ChargeMultiplier}";
                KKBonusKiPerSecond.Text = $"{kkf.BonusKiPerSecond}";
                KKStrainPerSecond.Text = $"{kkf.StrainPerSecond}";
                KKMasteryReq.Text = $"{kkf.BaseMasteryLevelsToUnlock}";
                KKHealthDrain.Text = $"{kkf.HealthDrainPercentBonus}";
                KKRedIntensityTrack.Value = (int)(kkf.SkinColorRedIntensity * 100);
            }
         }

        private void KKSave_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog {
                Filter = "Kaioken Transformation files (*.kkf)|*.kkf",
                FileName = $"{KKAbbriviation.Text}.kkf"
            };

            if (sfd.ShowDialog() == DialogResult.OK) {
                FlatBufferBuilder fbb = new FlatBufferBuilder(256);

                var name = fbb.CreateString(KKName.Text);
                var abbr = fbb.CreateString(KKAbbriviation.Text);

                KaiokenTransformation.StartKaiokenTransformation(fbb);

                KaiokenTransformation.AddName(fbb, name);
                KaiokenTransformation.AddNameAbbriviation(fbb, abbr);
                KaiokenTransformation.AddAura(fbb, (Aura)(byte)KKLoopingAura.SelectedIndex);
                KaiokenTransformation.AddAuraStart(fbb, (AuraStart)(byte)KKStartingAura.SelectedIndex);
                AuraSounds auraSound = AuraSounds.SSJ;

                switch (KKAuraSound.SelectedIndex) {
                    case 0:
                        auraSound = AuraSounds.SSJ3;
                        break;
                    case 1:
                        auraSound = AuraSounds.SSJ2;
                        break;
                    case 2:
                        auraSound = AuraSounds.SSJ;
                        break;
                    case 3:
                        auraSound = AuraSounds.SSG;
                        break;
                    case 4:
                        auraSound = AuraSounds.SSB;
                        break;
                    case 5:
                        auraSound = AuraSounds.SSR;
                        break;
                    case 6:
                        auraSound = AuraSounds.Kaioken;
                        break;
                }

                KaiokenTransformation.AddAuraSounds(fbb, auraSound);
                KaiokenTransformation.AddDamagePercentBonus(fbb, float.Parse(KKDamageBonus.Text));
                KaiokenTransformation.AddAttackSpeedPercentBonus(fbb, float.Parse(KKAttackSpeedBonus.Text));
                KaiokenTransformation.AddMoveSpeedPercentBonus(fbb, float.Parse(KKMoveSpeedBonus.Text));
                KaiokenTransformation.AddHealthDrainPercentBonus(fbb, float.Parse(KKHealthDrain.Text));
                KaiokenTransformation.AddChargeMultiplier(fbb, float.Parse(KKChargeMultiplier.Text));
                KaiokenTransformation.AddBonusKiPerSecond(fbb, float.Parse(KKBonusKiPerSecond.Text));
                KaiokenTransformation.AddStrainPerSecond(fbb, float.Parse(KKStrainPerSecond.Text));
                KaiokenTransformation.AddBaseMasteryLevelsToUnlock(fbb, (int)float.Parse(KKMasteryReq.Text));
                KaiokenTransformation.AddSkinColorRedIntensity(fbb, KKRedIntensityTrack.Value / 100f);

                KaiokenTransformation.FinishKaiokenTransformationBuffer(fbb, KaiokenTransformation.EndKaiokenTransformation(fbb));
                using var ms = new MemoryStream(fbb.DataBuffer.Data, fbb.DataBuffer.Position, fbb.Offset);
                File.WriteAllBytes(sfd.FileName, ms.ToArray());
            }
        }
    }
}
