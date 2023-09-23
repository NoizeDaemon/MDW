using Avalonia;
using Avalonia.Media;
using Material.Colors;
using Material.Styles.Themes;

namespace MarkDownWiki;

public static class Themes
{
    //public static Theme CustomLight = Theme.Create(Theme.Light, LookUp(PrimaryColor.Lime), LookUp(SecondaryColor.Indigo));
    //public static Theme CustomDark = Theme.Create(Theme.Dark, LookUp(PrimaryColor.Red), Colors.Violet);
    //public static Theme PinkGoodness = Theme.Create(Theme.Light, Colors.DeepPink, Colors.HotPink);


    static Themes() // Brush Overrides
    {
        //CustomLight.Paper = Colors.AliceBlue;

        //PinkGoodness.Paper = Colors.LightPink;
        //PinkGoodness.PrimaryDark = Colors.Pink;
    }

    public static Color LookUp(PrimaryColor primaryColor)
    {
        return SwatchHelper.Lookup[(MaterialColor)primaryColor];
    }

    public static Color LookUp(SecondaryColor primaryColor)
    {
        return SwatchHelper.Lookup[(MaterialColor)primaryColor];
    }

    public static void Change(bool isDarkMode, Color primary, Color secondary)
    {
        var theme = Theme.Create(isDarkMode ? Theme.Dark : Theme.Light, primary, secondary);
        var themeBootstrap = Application.Current!.LocateMaterialTheme<MaterialThemeBase>();
        themeBootstrap.CurrentTheme = theme;
    }

    public static void Change(Theme theme)
    {
        var themeBootstrap = Application.Current!.LocateMaterialTheme<MaterialThemeBase>();
        themeBootstrap.CurrentTheme = theme;
    }
}