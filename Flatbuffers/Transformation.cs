// automatically generated, do not modify

namespace AddedFormTool
{

using FlatBuffers;

public enum AllowedCharacters : byte
{
 Goku = 0,
 Vegeta = 1,
 Trunks = 2,
 GokuVegeta = 3,
 GokuTrunks = 4,
 VegetaTrunks = 5,
 GokuVegetaTrunks = 6,
};

public enum HairIndex : byte
{
 NORMAL = 0,
 SSJ = 1,
 SSJ3 = 2,
 UI = 3,
 NONE = 4,
 MAX_COUNT = 5,
};

public enum TransformSounds : uint
{
 UI = 739608199,
 Generic = 1019635502,
};

public enum AuraSounds : uint
{
 SSJ3 = 885148556,
 SSJ2 = 885148557,
 SSJ = 1093048485,
 SSG = 1093048488,
 SSB = 1093048493,
 SSR = 1093048509,
 Kaioken = 2147483647,
};

public enum CutsceneAuraStart : sbyte
{
 None = 0,
 SSJ4 = 1,
 SSRg = 2,
 UI = 3,
};

public enum Aura : byte
{
 Kaioken = 0,
 Kaiokenx3 = 1,
 Kaiokenx10 = 2,
 Kaiokenx20 = 3,
 SSJ = 4,
 SSJ2 = 5,
 SSJ3 = 6,
 SSJ4 = 7,
 SSJ5 = 8,
 SSG = 9,
 SSB = 10,
 SSR = 11,
 SSRg = 12,
 SSBE = 13,
 UI = 14,
};

public enum AuraStart : byte
{
 Kaioken = 0,
 SSJ = 1,
 SSJ4 = 2,
 SSJ5 = 3,
 SSG = 4,
 SSB = 5,
 SSR = 6,
 SSRg = 7,
 SSBE = 8,
 UI = 9,
};

public enum UltimateAttack : byte
{
 AngryKamehameha = 0,
 KiBlastBarrage = 1,
 DragonFist = 2,
 KamehamehaX10 = 3,
 WhiteDragonFist = 4,
 GodBind = 5,
 GodFistKamehameha = 6,
 BlackKamehameha = 7,
 GodlyDisplay = 8,
 BigBangAttack = 9,
 FinalFlash = 10,
 FinalExplosion = 11,
 FinalShineAttack = 12,
 ProminenceFlash = 13,
 NiagraPummel = 14,
 FullPowerFinalExplosion = 15,
 Masenko = 16,
 HeatDomeAttack = 17,
 InexperiencedPowerUp = 18,
 SwordOfHope = 19,
};

public sealed class Color : Struct {
  public Color __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public byte R { get { return bb.Get(bb_pos + 0); } }
  public byte G { get { return bb.Get(bb_pos + 1); } }
  public byte B { get { return bb.Get(bb_pos + 2); } }

  public static Offset<Color> CreateColor(FlatBufferBuilder builder, byte R, byte G, byte B) {
    builder.Prep(1, 3);
    builder.PutByte(B);
    builder.PutByte(G);
    builder.PutByte(R);
    return new Offset<Color>(builder.Offset);
  }
};

public sealed class Transformation : Table {
  public static Transformation GetRootAsTransformation(ByteBuffer _bb) { return GetRootAsTransformation(_bb, new Transformation()); }
  public static Transformation GetRootAsTransformation(ByteBuffer _bb, Transformation obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Transformation __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string Name { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public string NameAbbriviation { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public Aura Aura { get { int o = __offset(8); return o != 0 ? (Aura)bb.Get(o + bb_pos) : (Aura)0; } }
  public AuraStart AuraStart { get { int o = __offset(10); return o != 0 ? (AuraStart)bb.Get(o + bb_pos) : (AuraStart)0; } }
  public CutsceneAuraStart CutsceneAuraStart { get { int o = __offset(12); return o != 0 ? (CutsceneAuraStart)bb.GetSbyte(o + bb_pos) : (CutsceneAuraStart)0; } }
  public TransformSounds TransformSounds { get { int o = __offset(14); return o != 0 ? (TransformSounds)bb.GetUint(o + bb_pos) : (TransformSounds)1019635502; } }
  public AuraSounds AuraSounds { get { int o = __offset(16); return o != 0 ? (AuraSounds)bb.GetUint(o + bb_pos) : (AuraSounds)1093048485; } }
  public float KiDrain { get { int o = __offset(18); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float DamagePercentBonus { get { int o = __offset(20); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float ArmorPercentBonus { get { int o = __offset(22); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float AttackSpeedPercentBonus { get { int o = __offset(24); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float MoveSpeedPercentBonus { get { int o = __offset(26); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float RegenPercentBonus { get { int o = __offset(28); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float ChargeMultiplier { get { int o = __offset(30); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float StrainMultiplier { get { int o = __offset(32); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float ExpCostMultiplier { get { int o = __offset(34); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public HairIndex HairIndex { get { int o = __offset(36); return o != 0 ? (HairIndex)bb.Get(o + bb_pos) : (HairIndex)0; } }
  public Color HairColor { get { return GetHairColor(new Color()); } }
  public Color GetHairColor(Color obj) { int o = __offset(38); return o != 0 ? obj.__init(o + bb_pos, bb) : null; }
  public Color EyeColor { get { return GetEyeColor(new Color()); } }
  public Color GetEyeColor(Color obj) { int o = __offset(40); return o != 0 ? obj.__init(o + bb_pos, bb) : null; }
  public Color GuiTextColor { get { return GetGuiTextColor(new Color()); } }
  public Color GetGuiTextColor(Color obj) { int o = __offset(42); return o != 0 ? obj.__init(o + bb_pos, bb) : null; }
  public Color KiChargeColor { get { return GetKiChargeColor(new Color()); } }
  public Color GetKiChargeColor(Color obj) { int o = __offset(44); return o != 0 ? obj.__init(o + bb_pos, bb) : null; }
  public int MasteryLevelsToUnlock { get { int o = __offset(46); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
  public float ChestScale { get { int o = __offset(48); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float ArmsScale { get { int o = __offset(50); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public float LegsScale { get { int o = __offset(52); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public bool TeleportOnMelee { get { int o = __offset(54); return o != 0 ? 0!=bb.Get(o + bb_pos) : (bool)false; } }
  public float DodgeChance { get { int o = __offset(56); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
  public UltimateAttack SelectedUltimateAttack { get { int o = __offset(58); return o != 0 ? (UltimateAttack)bb.Get(o + bb_pos) : (UltimateAttack)0; } }
  public AllowedCharacters AllowedCharacters { get { int o = __offset(60); return o != 0 ? (AllowedCharacters)bb.Get(o + bb_pos) : (AllowedCharacters)0; } }

  public static void StartTransformation(FlatBufferBuilder builder) { builder.StartObject(29); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddNameAbbriviation(FlatBufferBuilder builder, StringOffset nameAbbriviationOffset) { builder.AddOffset(1, nameAbbriviationOffset.Value, 0); }
  public static void AddAura(FlatBufferBuilder builder, Aura aura) { builder.AddByte(2, (byte)(aura), 0); }
  public static void AddAuraStart(FlatBufferBuilder builder, AuraStart auraStart) { builder.AddByte(3, (byte)(auraStart), 0); }
  public static void AddCutsceneAuraStart(FlatBufferBuilder builder, CutsceneAuraStart cutsceneAuraStart) { builder.AddSbyte(4, (sbyte)(cutsceneAuraStart), 0); }
  public static void AddTransformSounds(FlatBufferBuilder builder, TransformSounds transformSounds) { builder.AddUint(5, (uint)(transformSounds), 1019635502); }
  public static void AddAuraSounds(FlatBufferBuilder builder, AuraSounds auraSounds) { builder.AddUint(6, (uint)(auraSounds), 1093048485); }
  public static void AddKiDrain(FlatBufferBuilder builder, float kiDrain) { builder.AddFloat(7, kiDrain, 0); }
  public static void AddDamagePercentBonus(FlatBufferBuilder builder, float damagePercentBonus) { builder.AddFloat(8, damagePercentBonus, 0); }
  public static void AddArmorPercentBonus(FlatBufferBuilder builder, float armorPercentBonus) { builder.AddFloat(9, armorPercentBonus, 0); }
  public static void AddAttackSpeedPercentBonus(FlatBufferBuilder builder, float attackSpeedPercentBonus) { builder.AddFloat(10, attackSpeedPercentBonus, 0); }
  public static void AddMoveSpeedPercentBonus(FlatBufferBuilder builder, float moveSpeedPercentBonus) { builder.AddFloat(11, moveSpeedPercentBonus, 0); }
  public static void AddRegenPercentBonus(FlatBufferBuilder builder, float regenPercentBonus) { builder.AddFloat(12, regenPercentBonus, 0); }
  public static void AddChargeMultiplier(FlatBufferBuilder builder, float chargeMultiplier) { builder.AddFloat(13, chargeMultiplier, 0); }
  public static void AddStrainMultiplier(FlatBufferBuilder builder, float strainMultiplier) { builder.AddFloat(14, strainMultiplier, 0); }
  public static void AddExpCostMultiplier(FlatBufferBuilder builder, float expCostMultiplier) { builder.AddFloat(15, expCostMultiplier, 0); }
  public static void AddHairIndex(FlatBufferBuilder builder, HairIndex hairIndex) { builder.AddByte(16, (byte)(hairIndex), 0); }
  public static void AddHairColor(FlatBufferBuilder builder, Offset<Color> hairColorOffset) { builder.AddStruct(17, hairColorOffset.Value, 0); }
  public static void AddEyeColor(FlatBufferBuilder builder, Offset<Color> eyeColorOffset) { builder.AddStruct(18, eyeColorOffset.Value, 0); }
  public static void AddGuiTextColor(FlatBufferBuilder builder, Offset<Color> guiTextColorOffset) { builder.AddStruct(19, guiTextColorOffset.Value, 0); }
  public static void AddKiChargeColor(FlatBufferBuilder builder, Offset<Color> kiChargeColorOffset) { builder.AddStruct(20, kiChargeColorOffset.Value, 0); }
  public static void AddMasteryLevelsToUnlock(FlatBufferBuilder builder, int masteryLevelsToUnlock) { builder.AddInt(21, masteryLevelsToUnlock, 0); }
  public static void AddChestScale(FlatBufferBuilder builder, float chestScale) { builder.AddFloat(22, chestScale, 0); }
  public static void AddArmsScale(FlatBufferBuilder builder, float armsScale) { builder.AddFloat(23, armsScale, 0); }
  public static void AddLegsScale(FlatBufferBuilder builder, float legsScale) { builder.AddFloat(24, legsScale, 0); }
  public static void AddTeleportOnMelee(FlatBufferBuilder builder, bool teleportOnMelee) { builder.AddBool(25, teleportOnMelee, false); }
  public static void AddDodgeChance(FlatBufferBuilder builder, float dodgeChance) { builder.AddFloat(26, dodgeChance, 0); }
  public static void AddSelectedUltimateAttack(FlatBufferBuilder builder, UltimateAttack selectedUltimateAttack) { builder.AddByte(27, (byte)(selectedUltimateAttack), 0); }
  public static void AddAllowedCharacters(FlatBufferBuilder builder, AllowedCharacters allowedCharacters) { builder.AddByte(28, (byte)(allowedCharacters), 0); }
  public static Offset<Transformation> EndTransformation(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Transformation>(o);
  }
  public static void FinishTransformationBuffer(FlatBufferBuilder builder, Offset<Transformation> offset) { builder.Finish(offset.Value); }
};


}
