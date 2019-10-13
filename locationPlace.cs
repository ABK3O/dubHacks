using System;

public class locationPlace
{
    public String location;
    public String address;
    public int dist;
	public locationPlace()
	{
        location = "";
        address = "";
        dist = 0;
	}

    public void addLocation(string location)
    {
        this.location = location;
    }
    public void addAddress(string address)
    {
        this.Address = address;
    }
    public void addLocation(int dist)
    {
        this.dist = dist;
    }

}
