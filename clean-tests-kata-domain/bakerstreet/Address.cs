
using System;

public class Address {

    public readonly String street;
    public readonly String city;
    public readonly PostCode postCode;

    public Address(String street, String city, PostCode postCode) {
        this.street = street;
        this.city = city;
        this.postCode = postCode;
    }

}
