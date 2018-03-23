Public Class Globals
    Public Shared ReadOnly CurrentPackagePath As String = Application.StartupPath & "\CurrentPak.zip"

    Public Shared ReadOnly SeedingPackageName As String = "PackageSeeds.Data"
    Public Shared ReadOnly SettingsPackageName As String = "Settings.GameProperties"
    Public Shared ReadOnly CameraPackageName As String = "Camera"

    Public Shared ReadOnly LevelPackageSuffix As String = ".level"

    Public Shared ReadOnly DeafultIcon As Icon = Icon.FromHandle(My.Resources.DragonIcon.GetHicon())
End Class
