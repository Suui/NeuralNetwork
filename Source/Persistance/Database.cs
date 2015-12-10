using System;
using Npgsql;
using Source.NeuralNetworks;


namespace Source.Persistance
{
	public class Database
	{
		private const string ConnectionString = "Host=127.0.0.1;" +
		                                         "Username=intelligent_systems;" +
		                                         "Password=intelligent_systems;" +
		                                         "Database=intelligent_systems;";

		public void SaveValuesFor(NeuralNetwork neuralNetwork)
		{
			var firstLayerWeights = neuralNetwork.GetWeightsForLayer(1);
			var secondLayerWeights = neuralNetwork.GetWeightsForLayer(2);

			var secondLayerThresholds = neuralNetwork.GetThresholdsForLayer(2);
			var thirdLayerThresholds = neuralNetwork.GetThresholdsForLayer(3);

			try
			{
				var connection = new NpgsqlConnection(ConnectionString);
				connection.Open();
				var command = new NpgsqlCommand { Connection = connection };

				for (var i = 1; i <= secondLayerThresholds.Count; i++)
				{
					command.CommandText = "UPDATE pr4_thresholds_layer2 SET threshold=" + secondLayerThresholds[i - 1] + " WHERE id=" + i;
					command.ExecuteNonQuery();
				}

				for (var i = 1; i <= thirdLayerThresholds.Count; i++)
				{
					command.CommandText = "UPDATE pr4_thresholds_layer3 SET threshold=" + thirdLayerThresholds[i - 1] + " WHERE id=" + i;
					command.ExecuteNonQuery();
				}


				for (var i = 1; i <= firstLayerWeights.Count; i++)
				{
					command.CommandText = "UPDATE pr4_weights_layer1 SET weight=" + firstLayerWeights[i - 1] + " WHERE id=" + i;
					command.ExecuteNonQuery();
				}

				for (var i = 1; i <= secondLayerWeights.Count; i++)
				{
					command.CommandText = "UPDATE pr4_weights_layer2 SET weight=" + secondLayerWeights[i - 1] + " WHERE id=" + i;
					command.ExecuteNonQuery();
				}

				connection.Close();
			}
			catch (Exception)
			{
				Console.WriteLine("There was a problem saving values in the database.");
				throw;
			}
		}

		public void LoadValuesFor(NeuralNetwork neuralNetwork)
		{
			var firstLayerWeights = new ValueList<double>();
			var secondLayerWeights = new ValueList<double>();

			var secondLayerThresholds = new ValueList<double>();
			var thirdLayerThresholds = new ValueList<double>();

			try
			{
				var connection = new NpgsqlConnection(ConnectionString);
				connection.Open();
				var command = new NpgsqlCommand { Connection = connection };

				command.CommandText = "SELECT weight FROM pr4_weights_layer1 ORDER BY id ASC";
				var reader = command.ExecuteReader();

				while (reader.Read())
					firstLayerWeights.Add(reader.GetDouble(0));

				reader.Close();
				command.CommandText = "SELECT weight FROM pr4_weights_layer2 ORDER BY id ASC";
				reader = command.ExecuteReader();

				while (reader.Read())
					secondLayerWeights.Add(reader.GetDouble(0));

				reader.Close();
				command.CommandText = "SELECT threshold FROM pr4_thresholds_layer2 ORDER BY id ASC";
				reader = command.ExecuteReader();

				while (reader.Read())
					secondLayerThresholds.Add(reader.GetDouble(0));

				reader.Close();
				command.CommandText = "SELECT threshold FROM pr4_thresholds_layer3 ORDER BY id ASC";
				reader = command.ExecuteReader();

				while (reader.Read())
					thirdLayerThresholds.Add(reader.GetDouble(0));

				neuralNetwork.SetWeightsForLayer(1, firstLayerWeights);
				neuralNetwork.SetWeightsForLayer(2, secondLayerWeights);

				neuralNetwork.SetThresholdsForLayer(2, secondLayerThresholds);
				neuralNetwork.SetThresholdsForLayer(3, thirdLayerThresholds);
			}
			catch (Exception)
			{
				Console.WriteLine("There was a problem loading values from the database.");
				throw;
			}
		}
	}
}