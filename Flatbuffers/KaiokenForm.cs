using FlatBuffers;

namespace AddedFormTool {
    public sealed class KaiokenTransformation : Table {
        public static KaiokenTransformation GetRootAsKaiokenTransformation(ByteBuffer _bb) { return GetRootAsKaiokenTransformation(_bb, new KaiokenTransformation()); }
        public static KaiokenTransformation GetRootAsKaiokenTransformation(ByteBuffer _bb, KaiokenTransformation obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
        public KaiokenTransformation __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

        public string Name { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
        public string NameAbbriviation { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
        public Aura Aura { get { int o = __offset(8); return o != 0 ? (Aura)bb.Get(o + bb_pos) : (Aura)0; } }
        public AuraStart AuraStart { get { int o = __offset(10); return o != 0 ? (AuraStart)bb.Get(o + bb_pos) : (AuraStart)0; } }
        public AuraSounds AuraSounds { get { int o = __offset(12); return o != 0 ? (AuraSounds)bb.GetUint(o + bb_pos) : (AuraSounds)1093048485; } }
        public float DamagePercentBonus { get { int o = __offset(14); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float AttackSpeedPercentBonus { get { int o = __offset(16); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float MoveSpeedPercentBonus { get { int o = __offset(18); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float HealthDrainPercentBonus { get { int o = __offset(20); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float ChargeMultiplier { get { int o = __offset(22); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float BonusKiPerSecond { get { int o = __offset(24); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public float StrainPerSecond { get { int o = __offset(26); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }
        public int BaseMasteryLevelsToUnlock { get { int o = __offset(28); return o != 0 ? bb.GetInt(o + bb_pos) : (int)0; } }
        public float SkinColorRedIntensity { get { int o = __offset(30); return o != 0 ? bb.GetFloat(o + bb_pos) : (float)0; } }

        public static Offset<KaiokenTransformation> CreateKaiokenTransformation(FlatBufferBuilder builder,
            StringOffset name = default(StringOffset),
            StringOffset name_abbriviation = default(StringOffset),
            Aura aura = (Aura)0,
            AuraStart aura_start = (AuraStart)0,
            AuraSounds aura_sounds = (AuraSounds)1093048485,
            float damage_percent_bonus = 0,
            float attack_speed_percent_bonus = 0,
            float move_speed_percent_bonus = 0,
            float health_drain_percent_bonus = 0,
            float charge_multiplier = 0,
            float bonus_ki_per_second = 0,
            float strain_per_second = 0,
            int base_mastery_levels_to_unlock = 0,
            float skin_color_red_intensity = 0) {
            builder.StartObject(14);
            AddSkinColorRedIntensity(builder, skin_color_red_intensity);
            AddBaseMasteryLevelsToUnlock(builder, base_mastery_levels_to_unlock);
            AddStrainPerSecond(builder, strain_per_second);
            AddBonusKiPerSecond(builder, bonus_ki_per_second);
            AddChargeMultiplier(builder, charge_multiplier);
            AddHealthDrainPercentBonus(builder, health_drain_percent_bonus);
            AddMoveSpeedPercentBonus(builder, move_speed_percent_bonus);
            AddAttackSpeedPercentBonus(builder, attack_speed_percent_bonus);
            AddDamagePercentBonus(builder, damage_percent_bonus);
            AddAuraSounds(builder, aura_sounds);
            AddNameAbbriviation(builder, name_abbriviation);
            AddName(builder, name);
            AddAuraStart(builder, aura_start);
            AddAura(builder, aura);
            return EndKaiokenTransformation(builder);
        }

        public static void StartKaiokenTransformation(FlatBufferBuilder builder) { builder.StartObject(14); }
        public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
        public static void AddNameAbbriviation(FlatBufferBuilder builder, StringOffset nameAbbriviationOffset) { builder.AddOffset(1, nameAbbriviationOffset.Value, 0); }
        public static void AddAura(FlatBufferBuilder builder, Aura aura) { builder.AddByte(2, (byte)(aura), 0); }
        public static void AddAuraStart(FlatBufferBuilder builder, AuraStart auraStart) { builder.AddByte(3, (byte)(auraStart), 0); }
        public static void AddAuraSounds(FlatBufferBuilder builder, AuraSounds auraSounds) { builder.AddUint(4, (uint)(auraSounds), 1093048485); }
        public static void AddDamagePercentBonus(FlatBufferBuilder builder, float damagePercentBonus) { builder.AddFloat(5, damagePercentBonus, 0); }
        public static void AddAttackSpeedPercentBonus(FlatBufferBuilder builder, float attackSpeedPercentBonus) { builder.AddFloat(6, attackSpeedPercentBonus, 0); }
        public static void AddMoveSpeedPercentBonus(FlatBufferBuilder builder, float moveSpeedPercentBonus) { builder.AddFloat(7, moveSpeedPercentBonus, 0); }
        public static void AddHealthDrainPercentBonus(FlatBufferBuilder builder, float healthDrainPercentBonus) { builder.AddFloat(8, healthDrainPercentBonus, 0); }
        public static void AddChargeMultiplier(FlatBufferBuilder builder, float chargeMultiplier) { builder.AddFloat(9, chargeMultiplier, 0); }
        public static void AddBonusKiPerSecond(FlatBufferBuilder builder, float bonusKiPerSecond) { builder.AddFloat(10, bonusKiPerSecond, 0); }
        public static void AddStrainPerSecond(FlatBufferBuilder builder, float strainPerSecond) { builder.AddFloat(11, strainPerSecond, 0); }
        public static void AddBaseMasteryLevelsToUnlock(FlatBufferBuilder builder, int baseMasteryLevelsToUnlock) { builder.AddInt(12, baseMasteryLevelsToUnlock, 0); }
        public static void AddSkinColorRedIntensity(FlatBufferBuilder builder, float skinColorRedIntensity) { builder.AddFloat(13, skinColorRedIntensity, 0); }
        public static Offset<KaiokenTransformation> EndKaiokenTransformation(FlatBufferBuilder builder) {
            int o = builder.EndObject();
            return new Offset<KaiokenTransformation>(o);
        }
        public static void FinishKaiokenTransformationBuffer(FlatBufferBuilder builder, Offset<KaiokenTransformation> offset) { builder.Finish(offset.Value); }
    };


}
