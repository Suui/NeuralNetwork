using System;
using Npgsql;
using Source.NeuralNetworks;


namespace Source.Persistance
{
	public class Database
	{
		public void SaveValuesFor(NeuralNetwork neuralNetwork)
		{
			var firstLayerWeights = neuralNetwork.GetWeightsForLayer(1);
			var secondLayerWeights = neuralNetwork.GetWeightsForLayer(2);

			var secondLayerThresholds = neuralNetwork.GetThresholdsForLayer(2);
			var thirdLayerThresholds = neuralNetwork.GetThresholdsForLayer(3);

			const string connectionString = "Host=127.0.0.1;" +
											"Username=intelligent_systems;" +
											"Password=intelligent_systems;" +
											"Database=intelligent_systems;";

			try
			{
				var connection = new NpgsqlConnection(connectionString);
				connection.Open();
				var command = new NpgsqlCommand { Connection = connection };

				for (var i = 1; i <= secondLayerThresholds.Count; i++)
				{
					command.CommandText = "UPDATE pr4_thresholds_layer2 SET threshold=" + secondLayerThresholds[i-1] + " WHERE id=" + i;
					command.ExecuteNonQuery();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}