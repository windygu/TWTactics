using System;
using System.Collections.Generic;
using TribalWars.Villages;
using TribalWars.Worlds;

namespace TribalWars.Maps.Manipulators.AttackPlans
{
    /// <summary>
    /// Data holder for one attack plan (= one target)
    /// </summary>
    public class AttackPlan
    {
        #region Properties
        /// <summary>
        /// The village we will attack (or defend)
        /// </summary>
        public Village Target { get; set; }

        /// <summary>
        /// Arrival time for the troops
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// Villages attacking the target village
        /// </summary>
        public List<AttackPlanFrom> Attacks { get; private set; }
        #endregion

        #region Constructors
        public AttackPlan(Village target, DateTime? arrivalTime)
        {
            Target = target;
            if (arrivalTime.HasValue)
            {
                ArrivalTime = arrivalTime.Value;
            }
            else
            {
                ArrivalTime = World.Default.Settings.ServerTime.AddHours(8);
            }
            Attacks = new List<AttackPlanFrom>();
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Target={0}, ArrivalTime={1}, Attacks={2}", Target.LocationString, ArrivalTime.ToString("dd/MM hh:mm:ss"), Attacks.Count);
        }
    }
}