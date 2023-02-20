using System;
using System.Collections.Generic;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;


namespace Tenchex.Models
{
	public class TenchexContext : DbContext
	{
		public TenchexContext(DbContextOptions<TenchexContext> options) : base(options) { }

		public DbSet<Employees> Employees { get; set; }
		public DbSet<Equipments> Equipments { get; set; }
		public DbSet<Instrumentations> Instrumentations { get; set; }
		public DbSet<Projects> Projects { get; set; }
		public DbSet<Suppliers> Suppliers { get; set; }
		public DbSet<Systems> Systems { get; set; }
		public DbSet<Vendors> Vendors { get; set; }
		public DbSet<Types> Types { get; set; }
		public DbSet<Cables> Cables { get; set; }
		public DbSet<Pipes> Pipes { get; set; }
		public DbSet<Compressors> compressors { get; set; }
		public DbSet<Tanks> Tanks { get; set; }
		public DbSet<Pumps> Pumps { get; set; }
		public DbSet<Valves> Valves { get; set; }
		public DbSet<PressureGauge> pressureGauges { get; set; }
		public DbSet<PressureTransmitter> pressureTransmitters { get; set; }
		public DbSet<DiffrentialPressureGauge> diffrentialPressureGauges { get; set; }
		public DbSet<DiffrentialPressureTransmitter> diffrentialPressureTransmitters { get; set; }
		public DbSet<TemperatureGauge> temperatureGauges { get; set; }
		public DbSet<TemperatureTransmitter> temperatureTransmitters { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employees>().ToTable(nameof(Employees));
			modelBuilder.Entity<Equipments>().ToTable(nameof(Equipments));
			modelBuilder.Entity<Instrumentations>().ToTable(nameof(Instrumentations));
			modelBuilder.Entity<Projects>().ToTable(nameof(Projects));
			modelBuilder.Entity<Suppliers>().ToTable(nameof(Suppliers));
			modelBuilder.Entity<Systems>().ToTable(nameof(Systems));
			modelBuilder.Entity<Vendors>().ToTable(nameof(Vendors));
			modelBuilder.Entity<Types>().ToTable(nameof(Types));
			modelBuilder.Entity<Cables>().ToTable(nameof(Cables));
			modelBuilder.Entity<Pipes>().ToTable(nameof(Pipes));
			modelBuilder.Entity<Compressors>().ToTable(nameof(Compressors));
			modelBuilder.Entity<Tanks>().ToTable(nameof(Tanks));
			modelBuilder.Entity<Pumps>().ToTable(nameof(Pumps));
			modelBuilder.Entity<Valves>().ToTable(nameof(Valves));
			modelBuilder.Entity<PressureGauge>().ToTable(nameof(PressureGauge));
			modelBuilder.Entity<PressureTransmitter>().ToTable(nameof(PressureTransmitter));
			modelBuilder.Entity<DiffrentialPressureGauge>().ToTable(nameof(DiffrentialPressureGauge));
			modelBuilder.Entity<DiffrentialPressureTransmitter>().ToTable(nameof(DiffrentialPressureTransmitter));
			modelBuilder.Entity<TemperatureGauge>().ToTable(nameof(TemperatureGauge));
			modelBuilder.Entity<TemperatureTransmitter>().ToTable(nameof(TemperatureTransmitter));
		}
	}
}
