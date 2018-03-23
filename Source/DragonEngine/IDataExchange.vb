Public Interface IDataExchange
    Sub FromStorage(storage As Byte())
    Function ToStorage() As Byte()
    Function GetPackageName() As String
End Interface
