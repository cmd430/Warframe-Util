Imports Newtonsoft.Json.Linq

Namespace Utils
    Module Stat_Utils

        '
        '   Functions to Manipulate Stats
        '

        Public Function GetBaseStat(ByVal Warframe As Dictionary(Of String, JObject), ByVal Stat As String)
            Dim res As Decimal = 0
            If Stat = "armor" Then
                res = CType(Warframe("stats")("armor"), Decimal)
            End If
            If Stat = "health" Then
                res = CType(Warframe("stats")("health"), Decimal)
            End If
            If Stat = "shield" Then
                res = CType(Warframe("stats")("shield"), Decimal)
            End If
            If Stat = "energy" Then
                res = CType(Warframe("stats")("energy"), Decimal)
            End If
            If Stat = "strength" Then
                res = CType(Warframe("stats")("strength"), Decimal)
            End If
            Return res
        End Function

        Public Function GetRankedStat(ByVal Warframe As Dictionary(Of String, JObject), ByVal Stat As String)
            Dim res As Decimal = 0
            If Stat = "armor" Then
                res = CType(Warframe("stats")("armor"), Decimal) * CType(Warframe("rank_multipliers")("armor"), Decimal)
                If Not Warframe("overides") Is Nothing Then
                    If TypeOf Warframe("overides").SelectToken("rank_multipliers.armor", errorWhenNoMatch:=False) Is Object Then
                        res = CType(Warframe("stats")("armor"), Decimal) * CType(Warframe("overides").SelectToken("rank_multipliers.armor"), Decimal)
                    End If
                End If
            End If
            If Stat = "health" Then
                res = CType(Warframe("stats")("health"), Decimal) * CType(Warframe("rank_multipliers")("health"), Decimal)
                If Not Warframe("overides") Is Nothing Then
                    If TypeOf Warframe("overides").SelectToken("rank_multipliers.health", errorWhenNoMatch:=False) Is Object Then
                        res = CType(Warframe("stats")("health"), Decimal) * CType(Warframe("overides").SelectToken("rank_multipliers.health"), Decimal)
                    End If
                End If
            End If
            If Stat = "shield" Then
                res = CType(Warframe("stats")("shield"), Decimal) * CType(Warframe("rank_multipliers")("shield"), Decimal)
                If Not Warframe("overides") Is Nothing Then
                    If TypeOf Warframe("overides").SelectToken("rank_multipliers.shield", errorWhenNoMatch:=False) Is Object Then
                        res = CType(Warframe("stats")("shield"), Decimal) * CType(Warframe("overides").SelectToken("rank_multipliers.shield"), Decimal)
                    End If
                End If
            End If
            If Stat = "energy" Then
                res = CType(Warframe("stats")("energy"), Decimal) * CType(Warframe("rank_multipliers")("energy"), Decimal)
                If Not Warframe("overides") Is Nothing Then
                    If TypeOf Warframe("overides").SelectToken("rank_multipliers.energy", errorWhenNoMatch:=False) Is Object Then
                        res = CType(Warframe("stats")("energy"), Decimal) * CType(Warframe("overides").SelectToken("rank_multipliers.energy"), Decimal)
                    End If
                End If
            End If
            If Stat = "strength" Then
                res = CType(Warframe("stats")("strength"), Decimal) * CType(Warframe("rank_multipliers")("strength"), Decimal)
                If Not Warframe("overides") Is Nothing Then
                    If TypeOf Warframe("overides").SelectToken("rank_multipliers.strength", errorWhenNoMatch:=False) Is Object Then
                        res = CType(Warframe("stats")("strength"), Decimal) * CType(Warframe("overides").SelectToken("rank_multipliers.strength"), Decimal)
                    End If
                End If
            End If
            Return res
        End Function

    End Module
End Namespace