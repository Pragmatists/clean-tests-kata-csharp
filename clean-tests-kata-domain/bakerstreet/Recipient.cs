using System;
using System.Runtime.InteropServices;

public class Recipient {

    public readonly String name;
    public readonly Address address;

    public Recipient(String name, Address address) {
        this.name = name;
        this.address = address;
    }

}
