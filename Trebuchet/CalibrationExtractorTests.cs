using FluentAssertions;

namespace Trebuchet;

public class CalibrationExtractorTests
{
    [Test]
    public void CalculateCalibration_SimpleTest()
    {
        var map = new List<string>
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };
        var result = CalibrationExtractor.CalculateCalibration(map);
        result.Should().Be(142);
    }
    
    [Test]
    public void CalculateCalibration_AdventTest()
    {
        var input = TrebuchetInput.AdventInput;
        var map = input.Split(Environment.NewLine);
        var result = CalibrationExtractor.CalculateCalibration(map);
        result.Should().Be(54697);
    }
    
    [Test]
    public void CalculateCalibrationWithStringDigits_SimpleTest()
    {
        var map = new List<string>
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        var result = CalibrationExtractor.CalculateCalibrationWithStringDigits(map);
        result.Should().Be(281);
    }
    
    [Test]
    public void CalculateCalibrationWithStringDigits_OverlappingDigits()
    {
        var map = new List<string>
        {
            "onetwothreefourfivesixseveneightnine"
        };
        var result = CalibrationExtractor.CalculateCalibrationWithStringDigits(map);
        result.Should().Be(19);
    }
    
    [Test]
    public void CalculateCalibrationWithStringDigits_AdventTest()
    {
        var input = TrebuchetInput.AdventInput;
        var map = input.Split(Environment.NewLine);
        var result = CalibrationExtractor.CalculateCalibrationWithStringDigits(map);
        result.Should().Be(54885);
    }
}