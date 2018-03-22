Public Interface IDataExchange
    Sub FromStorage(storage As Byte())
    Function ToStorage() As Byte()
End Interface
