Imports Newtonsoft.Json.Linq

Module MathUtils

    '
    '   Functions to help with Calculations
    '

    Public Function GetEffectiveHealth(Warframe As Dictionary(Of String, JObject))
        'TODO implement mods and other sources of ehp
        '     currently this is only EHP for rank 30 stats
        Dim armor As Decimal = GetRankedStat(Warframe, "armor")
        Dim health As Decimal = GetRankedStat(Warframe, "health")
        Dim shield As Decimal = GetRankedStat(Warframe, "shield")
        Dim armor_damage_reduction As Decimal = armor / (300 + armor)
        Dim effective_health As Decimal = (health / (1 - armor_damage_reduction)) + shield
        Return effective_health
    End Function

End Module
