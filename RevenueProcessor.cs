using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestesTarget.Model;

namespace TestesTarget;

public class RevenueProcessor
{
    public List<RevenueData> RevenueData ;

    public RevenueProcessor(string format, string filePath)
    {
        if (format.Equals("json", StringComparison.OrdinalIgnoreCase))
        {
            RevenueData = LoadFromJson(filePath);
        }
        else if (format.Equals("xml", StringComparison.OrdinalIgnoreCase))
        {
            RevenueData = LoadFromXml(filePath);
        }
    }

    private List<RevenueData> LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
        var revenueData = new List<RevenueData>();
        try
        {
            var jsonString = File.ReadAllText(filePath);
            Console.WriteLine("Arquivo JSON lido com sucesso!");

            revenueData = JsonSerializer.Deserialize<List<RevenueData>>(jsonString)!;

            if (revenueData == null || !revenueData.Any())
            {
                Console.WriteLine("Erro: Nenhum dado foi deserializado ou o arquivo está vazio.");
                revenueData = new List<RevenueData>();
            }
            else
            {
                Console.WriteLine($"Foram carregados {revenueData.Count} itens.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler ou deserializar o arquivo JSON: {ex.Message}");
        }
        return revenueData;
    }


    private List<RevenueData> LoadFromXml(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        try
        {
            string xmlContent = File.ReadAllText(filePath);

            string wrappedXml = $"<root>{xmlContent}</root>";

            var xDocument = XDocument.Parse(wrappedXml);

            return xDocument.Descendants("row")
                .Select(row => new RevenueData
                {
                    Day = int.Parse(row.Element("dia")?.Value ?? "0"),
                    Value = double.Parse(row.Element("valor")?.Value ?? "0", CultureInfo.InvariantCulture)
                })
                .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o XML: {ex.Message}");
            return new List<RevenueData>();
        }
    }


    public double CalculateLowestRevenue()
    {
        return RevenueData.Where(data => data.Value > 0).Min(data => data.Value);
    }

    public double CalculateHighestRevenue()
    {
        return RevenueData.Max(data => data.Value);
    }

    public double CalculateMonthlyAverage()
    {
        var validData = RevenueData.Where(data => data.Value > 0).ToList();
        return validData.Sum(data => data.Value) / validData.Count;
    }

    public int DaysAboveAverage()
    {
        double average = CalculateMonthlyAverage();
        return RevenueData.Count(data => data.Value > average);
    }
}