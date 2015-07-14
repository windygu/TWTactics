﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TribalWars.Villages;
using TribalWars.Villages.Helpers;
using TribalWars.Worlds;

namespace TribalWars.Controls.Finders
{
    /// <summary>
    /// A player or tribe row in the <see cref="PlayerTribeDropdown"/> MultiColumnDropdown
    /// </summary>
    public class PlayerOrTribeRow : IEquatable<PlayerOrTribeRow>
    {
        private readonly IVisible _visibilityGetter;

        public bool IsPlayer { get; set; }
        public bool IsTribe { get; set; }

        public string Value { get; set; }
        public string Text { get; set; }

        public int Rank { get; set; }

        public int ImageIndex
        {
            get
            {
                if (IsPlayer) return 1;
                if (IsTribe) return 2;
                return -1;
            }
        }

        public bool Visible
        {
            get
            {
                return _visibilityGetter.IsVisible(World.Default.Map);
            }
        }

        public string Tooltip { get; private set; }

        public PlayerOrTribeRow(Tribe tribe)
        {
            _visibilityGetter = tribe;
            Value = tribe.Tag;
            Text = string.Format(ControlsRes.PlayerOrTribeRow_Text, Tools.Common.GetPrettyNumber(tribe.AllPoints), tribe.Rank);
            Tooltip = tribe.Tooltip;
            Rank = tribe.Rank;
            IsTribe = true;
        }

        public PlayerOrTribeRow(Player player)
        {
            _visibilityGetter = player;
            Value = player.Name;
            Text = string.Format(ControlsRes.PlayerOrTribeRow_Text, Tools.Common.GetPrettyNumber(player.Points), player.Rank);
            Tooltip = player.Tooltip;
            Rank = player.Rank;
            IsPlayer = true;
        }

        public override string ToString()
        {
            return string.Format("Value={0}, Text={1}", Value, Text);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlayerOrTribeRow);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(PlayerOrTribeRow other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return false;
            return Value == other.Value
                   && IsPlayer == other.IsPlayer
                   && IsTribe == other.IsTribe;
        }
    }
}
