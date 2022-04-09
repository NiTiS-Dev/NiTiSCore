namespace NiTiS.Additions;

public delegate T Dipper<T>(T item);

public delegate bool Validator<in T>(T item);
public delegate bool Validator<in T1, in T2>(T1 item1, T2 item2);
public delegate bool Validator<in T1, in T2, in T3>(T1 item1, T2 item2, T3 item3);
public delegate bool Validator<in T1, in T2, in T3, in T4>(T1 item1, T2 item2, T3 item3, T4 item4);