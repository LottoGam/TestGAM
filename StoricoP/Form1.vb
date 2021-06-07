Option Explicit On

Public Class Form1

    Public Structure Record
        <VBFixedString(118)> Public Dati As String
        <VBFixedString(2)> Public EndOfRecord As String
    End Structure
    Public Structure RecordEstrazione
        <VBFixedString(8)> Public Data As String
        Public Ruota() As SingolaRuota
    End Structure
    Private RecordArchivio As Record
    Public Structure SingolaRuota
        Public Estratto() As Integer
    End Structure
    Public bestn9(0 To 9, 0 To 15, 0 To 2) As Long
    Public oldn9(0 To 9, 0 To 15, 0 To 2) As Long
    Public Estrazione As RecordEstrazione
    Public Estrazioni() As RecordEstrazione
    Public Estrazioni2() As RecordEstrazione
    Public best(0 To 15) As Long
    Public bestr(0 To 15) As Long
    Public old(0 To 15) As Long
    Public oldr(0 To 15) As Long
    Public ar1(0 To 10) As Long
    Public ar2(0 To 10) As Long
    Public uscito(0 To 10) As Long
    Public uscito2(0 To 10) As Long
    Public cinquina(0 To 5) As Long
    Public orig(0 To 10) As Long
    Public QE As Long
    Public Visx As String
    Public rand As Random
    Public RuotaD(0 To 10) As String
    Public SingolaRuota2 As SingolaRuota
    Public RecordEstrazione2 As RecordEstrazione
    <VBFixedString(118)> Public Alpha3 As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call CaricoEstr()
        Mess(Trim(Str(QE)) & " Estrazioni. Prima del " & CStr(Estrazioni(1).Data) & " - Ultima del " & CStr(Estrazioni(QE).Data) & ". ")
        Mess2(Visx)
        Button5.Enabled = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim SingolaRuota2.Estratto(5)
        ReDim RecordEstrazione2.Ruota(10)
        RuotaD(0) = "Nazionale"
        RuotaD(1) = "Bari"
        RuotaD(2) = "Cagliari"
        RuotaD(3) = "Firenze"
        RuotaD(4) = "Genova"
        RuotaD(5) = "Milano"
        RuotaD(6) = "Napoli"
        RuotaD(7) = "Palermo"
        RuotaD(8) = "Roma"
        RuotaD(9) = "Torino"
        RuotaD(10) = "Venezia"
    End Sub

    Private Sub Mess(Alpha As String)
        Me.Text = Alpha
    End Sub
    Private Sub Mess2(Alpha As String)
        Me.Text = Me.Text & " " & Alpha
    End Sub

    Private Sub Leggi()
        Alpha3 = RecordArchivio.Dati
        Dim I As Integer
        Dim II As Integer
        ReDim Preserve Estrazione.Ruota(10)
        ReDim Preserve Estrazione.Ruota(0).Estratto(5)
        ReDim Preserve Estrazione.Ruota(1).Estratto(5)
        ReDim Preserve Estrazione.Ruota(2).Estratto(5)
        ReDim Preserve Estrazione.Ruota(3).Estratto(5)
        ReDim Preserve Estrazione.Ruota(4).Estratto(5)
        ReDim Preserve Estrazione.Ruota(5).Estratto(5)
        ReDim Preserve Estrazione.Ruota(6).Estratto(5)
        ReDim Preserve Estrazione.Ruota(7).Estratto(5)
        ReDim Preserve Estrazione.Ruota(8).Estratto(5)
        ReDim Preserve Estrazione.Ruota(9).Estratto(5)
        ReDim Preserve Estrazione.Ruota(10).Estratto(5)
        Estrazione.Data = Mid$(Alpha3, 5, 4) + Mid$(Alpha3, 3, 2) + Mid$(Alpha3, 1, 2)
        For I = 1 To 11
            If I <> 11 Then
                For II = 1 To 5
                    Estrazione.Ruota(I).Estratto(II) = Val(Mid$(Alpha3, 8 + (I - 1) * 10 + 1 + (II - 1) * 2, 2))
                Next II
            Else
                For II = 1 To 5
                    Estrazione.Ruota(0).Estratto(II) = Val(Mid$(Alpha3, 8 + (I - 1) * 10 + 1 + (II - 1) * 2, 2))
                Next II
            End If
        Next I
    End Sub
    Sub CaricoEstr()
        Me.Cursor = Cursors.WaitCursor
        If System.IO.File.Exists("storico.txt") Then
            Kill("storico.txt")
        End If
        System.IO.Compression.ZipFile.ExtractToDirectory("storico.zip", ".")
        Dim oFile As System.IO.FileStream
        Dim oWriter As System.IO.StreamWriter
        oFile = New System.IO.FileStream("archivionew2", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
        oWriter = New System.IO.StreamWriter(oFile)
        Dim I As Long
        Dim II As Long
        Dim NomeFile As String
        Dim stream As System.IO.StreamReader
        Dim Alpha As String
        Dim AlphaB As String
        Dim AlphaC As String
        Dim AlphaRN As String
        Dim Vect() As String
        Dim NumX As String
        Dim Aggiunto As Long
        Alpha = ""
        AlphaB = ""
        AlphaRN = ""
        stream = System.IO.File.OpenText("storico.txt")
        For I = 1 To 5561
            AlphaB = stream.ReadLine()
        Next I
        AlphaC = "X"
        Do Until AlphaB Is Nothing
            Aggiunto = 0
            If AlphaB Is Nothing Then
                GoTo Esci1
            End If
            Alpha = ""
            AlphaRN = ""
            For I = 1 To 10
Ripeti1:
                AlphaB = stream.ReadLine()
                If AlphaB = AlphaC Then
                    GoTo Ripeti1
                End If
                AlphaC = AlphaB
                If I = 1 Then
                    Alpha = Mid$(AlphaB, 9, 2) + Mid$(AlphaB, 6, 2) + Mid$(AlphaB, 1, 4)
                End If
                If AlphaB Is Nothing Then
                    Exit For
                End If
                If InStr(AlphaB, "RN") <> 0 Then
                    Vect = Split(AlphaB, vbTab)
                    For II = 1 To 5
                        NumX = Vect(II + 1)
                        If Val(NumX) < 10 Then
                            NumX = "0" + NumX
                        End If
                        AlphaRN = AlphaRN + NumX
                    Next II
                    GoTo Ripeti1
                End If
                Vect = Split(AlphaB, vbTab)
                For II = 1 To 5
                    NumX = Vect(II + 1)
                    If Val(NumX) < 10 Then
                        NumX = "0" + NumX
                    End If
                    Alpha = Alpha + NumX
                Next II
            Next I
            If AlphaRN = "" Then AlphaRN = "0000000000"
            If AlphaB Is Nothing Then
                GoTo Esci1
            End If
            Alpha = Alpha & AlphaRN
            Aggiunto = 1
            oWriter.WriteLine(Alpha)
Esci1:
        Loop
        If Aggiunto = 0 Then
            If AlphaRN = "" Then
                AlphaRN = "0000000000"
            End If
            Alpha = Alpha & AlphaRN
        End If
        oWriter.WriteLine(Alpha)
        stream.Close()
        oWriter.Close()
        QE = 0
        NomeFile = "archivionew2"
        stream = System.IO.File.OpenText(NomeFile)
        Alpha = stream.ReadLine()
        Do Until Alpha Is Nothing
            QE = QE + 1
            ReDim Preserve Estrazioni(0 To QE)
            RecordArchivio.Dati = Alpha
            Call Leggi()
            Estrazioni(QE) = Estrazione
            Alpha = stream.ReadLine()
        Loop
        QE = QE - 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
        My.Computer.Network.DownloadFile("https://www.lottomatica.it/STORICO_ESTRAZIONI_LOTTO/storico.zip", "storico.zip.download", "", "", True, 4000, True)
        Kill("storico.zip")
        Rename("storico.zip.download", "storico.zip")
        MsgBox("Fatto.")
    End Sub

    Private Function Generate_Random_Number(ByVal Lower As Integer, ByVal Upper As Integer)
        Dim Random_Value As Integer
        Random_Value = rand.Next(Lower, Upper + 1)
        Return Random_Value
    End Function

    Private Sub VediArchivioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VediArchivioToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim builder As New System.Text.StringBuilder
        Dim Stringa As String
        Dim I As Long
        Dim stream As System.IO.StreamReader
        Dim AlphaB As String
        Dim AlphaC As String
        RichTextBox1.Text = ""
        AlphaB = ""
        Stringa = ""
        stream = System.IO.File.OpenText("storico.txt")
        For I = 1 To 5561
            AlphaB = stream.ReadLine()
        Next I
        AlphaC = "X"
        RichTextBox1.Visible = False
        Do While True
Ripeti11:
            AlphaB = stream.ReadLine()
            If AlphaB = AlphaC Then
                GoTo Ripeti11
            End If
            AlphaC = AlphaB
            If AlphaB Is Nothing Then
                GoTo Esci11
            End If
            builder.Append(AlphaB & vbCrLf)
        Loop
Esci11:
        stream.Close()
        RichTextBox1.Text = builder.ToString
        RichTextBox1.Visible = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Seed As String
        Dim Seme As Long
        Dim I As Long
        Dim x(0 To 4) As Integer
        Dim R As Long
        Dim II As Long
        Dim III As Long
        Dim fDoppio As Boolean
        Seed = InputBox("Inserire seed (0 = random seed):", Title:="Seme", DefaultResponse:="0")
        Seme = Int(Val(Seed))
        If Seme = 0 Then
            Randomize()
            Seme = Int(Rnd() * 10000)
        End If
        rand = New Random(Seme)
        For I = QE To 1 Step -1
            For R = 0 To 10
                If R <> 0 Or (R = 0 And Estrazioni(I).Ruota(0).Estratto(1) <> 0) Then
                    fDoppio = True
                    Do While fDoppio
                        For II = 0 To 4
                            x(II) = Generate_Random_Number(1, 90)
                        Next
                        fDoppio = False
                        For II = 0 To 3
                            For III = II + 1 To 4
                                If x(II) = x(III) Then fDoppio = True
                            Next
                        Next
                    Loop
                    For II = 0 To 4
                        Estrazioni(I).Ruota(R).Estratto(II + 1) = x(II)
                    Next
                End If
            Next
        Next
        MsgBox("Caricati dati Random. Seme:" & Str(Seme))
    End Sub

    Private Sub EstrazioniDispariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstrazioniDispariToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim builder As New System.Text.StringBuilder
        Dim Stringa As String
        Dim I As Long
        Dim stream As System.IO.StreamReader
        Dim AlphaB As String
        Dim AlphaC As String
        Dim Dispari As Long
        RichTextBox1.Text = ""
        AlphaB = ""
        Stringa = ""
        stream = System.IO.File.OpenText("storico.txt")
        For I = 1 To 5561
            AlphaB = stream.ReadLine()
        Next I
        AlphaC = "X"
        Dispari = 1
        RichTextBox1.Visible = False
        Do While True
Ripeti111:
            AlphaB = stream.ReadLine()
            If AlphaB = AlphaC Then
                GoTo Ripeti111
            End If
            AlphaC = AlphaB
            If AlphaB Is Nothing Then
                GoTo Esci111
            End If
            If Dispari = 1 Then
                builder.Append(AlphaB & vbCrLf)
            End If
            If InStr(AlphaB, "VE") <> 0 Then
                If Dispari = 1 Then
                    Dispari = 0
                Else
                    Dispari = 1
                End If
            End If
        Loop
Esci111:
        stream.Close()
        RichTextBox1.Text = builder.ToString
        RichTextBox1.Visible = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EstrazioniPariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstrazioniPariToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim builder As New System.Text.StringBuilder
        Dim Stringa As String
        Dim I As Long
        Dim stream As System.IO.StreamReader
        Dim AlphaB As String
        Dim AlphaC As String
        Dim Dispari As Long
        RichTextBox1.Text = ""
        AlphaB = ""
        Stringa = ""
        stream = System.IO.File.OpenText("storico.txt")
        For I = 1 To 5561
            AlphaB = stream.ReadLine()
        Next I
        AlphaC = "X"
        Dispari = 1
        RichTextBox1.Visible = False
        Do While True
Ripeti1111:
            AlphaB = stream.ReadLine()
            If AlphaB = AlphaC Then
                GoTo Ripeti1111
            End If
            AlphaC = AlphaB
            If AlphaB Is Nothing Then
                GoTo Esci1111
            End If
            If Dispari = 0 Then
                builder.Append(AlphaB & vbCrLf)
            End If
            If InStr(AlphaB, "VE") <> 0 Then
                If Dispari = 1 Then
                    Dispari = 0
                Else
                    Dispari = 1
                End If
            End If
        Loop
Esci1111:
        stream.Close()
        RichTextBox1.Text = builder.ToString
        RichTextBox1.Visible = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EnnambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnnambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Ennambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 9
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & oldn9(5, x1, 1) & "-" & oldn9(5, x1, 2) & " " & oldn9(6, x1, 1) & "-" & oldn9(6, x1, 2) & " " & oldn9(7, x1, 1) & "-" & oldn9(7, x1, 2) & " " & oldn9(8, x1, 1) & "-" & oldn9(8, x1, 2) & " " & oldn9(9, x1, 1) & "-" & oldn9(9, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & bestn9(5, x1, 1) & "-" & bestn9(5, x1, 2) & " " & bestn9(6, x1, 1) & "-" & bestn9(6, x1, 2) & " " & bestn9(7, x1, 1) & "-" & bestn9(7, x1, 2) & " " & bestn9(8, x1, 1) & "-" & bestn9(8, x1, 2) & " " & bestn9(9, x1, 1) & "-" & bestn9(9, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EsciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EsciToolStripMenuItem.Click
        End
    End Sub

    Private Sub OttambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OttambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Ottambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 8
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ8
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ8:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & oldn9(5, x1, 1) & "-" & oldn9(5, x1, 2) & " " & oldn9(6, x1, 1) & "-" & oldn9(6, x1, 2) & " " & oldn9(7, x1, 1) & "-" & oldn9(7, x1, 2) & " " & oldn9(8, x1, 1) & "-" & oldn9(8, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & bestn9(5, x1, 1) & "-" & bestn9(5, x1, 2) & " " & bestn9(6, x1, 1) & "-" & bestn9(6, x1, 2) & " " & bestn9(7, x1, 1) & "-" & bestn9(7, x1, 2) & " " & bestn9(8, x1, 1) & "-" & bestn9(8, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EptambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EptambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Eptambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 7
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ7
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ7:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & oldn9(5, x1, 1) & "-" & oldn9(5, x1, 2) & " " & oldn9(6, x1, 1) & "-" & oldn9(6, x1, 2) & " " & oldn9(7, x1, 1) & "-" & oldn9(7, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & bestn9(5, x1, 1) & "-" & bestn9(5, x1, 2) & " " & bestn9(6, x1, 1) & "-" & bestn9(6, x1, 2) & " " & bestn9(7, x1, 1) & "-" & bestn9(7, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EsambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EsambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Esambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 6
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ6
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ6:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & oldn9(5, x1, 1) & "-" & oldn9(5, x1, 2) & " " & oldn9(6, x1, 1) & "-" & oldn9(6, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & bestn9(5, x1, 1) & "-" & bestn9(5, x1, 2) & " " & bestn9(6, x1, 1) & "-" & bestn9(6, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PentambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PentambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Pentambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 5
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ5
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ5:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & oldn9(5, x1, 1) & "-" & oldn9(5, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & bestn9(5, x1, 1) & "-" & bestn9(5, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QuadrambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuadrambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Quadriambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 4
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ4
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ4:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & oldn9(4, x1, 1) & "-" & oldn9(4, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & bestn9(4, x1, 1) & "-" & bestn9(4, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TriambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TriambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Triambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 3
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ3
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ3:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & oldn9(3, x1, 1) & "-" & oldn9(3, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & bestn9(3, x1, 1) & "-" & bestn9(3, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BiambiResiduiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiambiResiduiToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        RichTextBox1.Text = ""
        Dim builder As New System.Text.StringBuilder
        builder.Append("Biambi Residui" & vbCrLf)
        builder.Append(Str(QE) & vbCrLf)
        Dim numambi As Long
        numambi = 2
        Dim x1, x2, x3, rit, found, foundf, nn, ambivergini, t, ruota, x, y As Long
        For x1 = 1 To numambi
            For x2 = 1 To 15
                old(x2) = 0
                oldr(x2) = 0
                best(x2) = 0
                bestr(x2) = 0
                For x3 = 1 To 2
                    oldn9(x1, x2, x3) = 0
                    bestn9(x1, x2, x3) = 0
                Next
            Next
        Next
        For ruota = 0 To 10
            For x = 1 To QE
                If Estrazioni(x).Ruota(ruota).Estratto(1) = 0 Then
                    GoTo NoNZ2
                End If
                cinquina(1) = Estrazioni(x).Ruota(ruota).Estratto(1)
                cinquina(2) = Estrazioni(x).Ruota(ruota).Estratto(2)
                cinquina(3) = Estrazioni(x).Ruota(ruota).Estratto(3)
                cinquina(4) = Estrazioni(x).Ruota(ruota).Estratto(4)
                cinquina(5) = Estrazioni(x).Ruota(ruota).Estratto(5)
                rit = 1
                found = 0
                foundf = 0
                t = 1
                For x1 = 1 To 4
                    For x2 = x1 + 1 To 5
                        ar1(t) = cinquina(x1)
                        ar2(t) = cinquina(x2)
                        uscito(t) = 0
                        t = t + 1
                    Next x2
                Next x1
                For x1 = 1 To 10
                    orig(x1) = 0
                Next x1

                For y = x + 1 To QE
                    For x1 = 1 To 10
                        uscito2(x1) = 0
                    Next x1
                    For x1 = 1 To 10
                        For x2 = 1 To 5
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar1(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                            If Estrazioni(y).Ruota(ruota).Estratto(x2) = ar2(x1) Then
                                uscito2(x1) = uscito2(x1) + 1
                            End If
                        Next x2
                    Next x1
                    For x1 = 1 To 10
                        If uscito2(x1) = 2 Then
                            uscito(x1) = 1
                        End If
                    Next x1
                    ambivergini = 0
                    For x1 = 1 To 10
                        If uscito(x1) = 0 Then
                            ambivergini = ambivergini + 1
                        End If
                    Next x1
                    If ambivergini < (numambi + 1) Then
                        If foundf = 0 Then
                            foundf = 1
                            For x1 = 1 To 10
                                t = 0
                                If uscito(x1) = 0 Then
                                    orig(x1) = 1
                                    t = t + 1
                                End If
                            Next x1
                        End If
                    End If
                    If ambivergini > (numambi - 1) Then
                        rit = rit + 1
                    Else
                        found = 1

                        For x1 = 1 To 15
                            If rit > old(x1) Then
                                For x2 = 14 To x1 Step -1
                                    old(x2 + 1) = old(x2)
                                    For x3 = 1 To numambi
                                        oldn9(x3, x2 + 1, 1) = oldn9(x3, x2, 1)
                                        oldn9(x3, x2 + 1, 2) = oldn9(x3, x2, 2)
                                    Next x3
                                    oldr(x2 + 1) = oldr(x2)
                                Next x2
                                old(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        oldn9(nn, x1, 1) = ar1(x2)
                                        oldn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                oldr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                        Exit For
                    End If
                Next y
                If foundf = 1 Then
                    If found = 0 Then
                        For x1 = 1 To 15
                            If rit > best(x1) Then
                                For x2 = 14 To x1 Step -1
                                    best(x2 + 1) = best(x2)
                                    For x3 = 1 To numambi
                                        bestn9(x3, x2 + 1, 1) = bestn9(x3, x2, 1)
                                        bestn9(x3, x2 + 1, 2) = bestn9(x3, x2, 2)
                                    Next x3
                                    bestr(x2 + 1) = bestr(x2)
                                Next x2
                                best(x1) = rit
                                nn = 1
                                For x2 = 1 To 10
                                    If orig(x2) = 1 Then
                                        bestn9(nn, x1, 1) = ar1(x2)
                                        bestn9(nn, x1, 2) = ar2(x2)
                                        nn = nn + 1
                                    End If
                                Next x2
                                bestr(x1) = ruota
                                Exit For
                            End If
                        Next x1
                    End If
                End If
NoNZ2:
            Next x
        Next ruota
        For x1 = 1 To 15
            builder.Append(x1 & ". " & old(x1) & " " & oldn9(1, x1, 1) & "-" & oldn9(1, x1, 2) & " " & oldn9(2, x1, 1) & "-" & oldn9(2, x1, 2) & " " & RuotaD(oldr(x1)) & vbCrLf)
        Next x1
        Dim ris, ris2 As Single
        Dim pos As Long
        pos = 16
        For x1 = 1 To 15
            If best(1) > old(x1) Then
                pos = x1
                Exit For
            End If
        Next x1
        ris = best(1) / old(1)
        ris2 = best(1) / ((old(1) + old(2) + old(3) + old(4) + old(5)) / 5)
        builder.Append("RATE " & Str(pos) & ". " & Str(ris) & " RATE5 " & Str(ris2) & vbCrLf)
        For x1 = 1 To 15
            builder.Append(x1 & ". " & best(x1) & " " & bestn9(1, x1, 1) & "-" & bestn9(1, x1, 2) & " " & bestn9(2, x1, 1) & "-" & bestn9(2, x1, 2) & " " & RuotaD(bestr(x1)) & vbCrLf)
        Next x1
        RichTextBox1.Text = builder.ToString
        RichTextBox1.SaveFile("Last.rtf")
        Me.Cursor = Cursors.Arrow
    End Sub
End Class