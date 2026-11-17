using System;
using System.Collections.Generic;
using System.Linq;

public class UserRepository
{
    private readonly OurContext _context;

    public UserRepository()
    {
        _context = new OurContext();
    }

    public bool Add(User user)
    {
        _context.Users.Add(user);
        return _context.SaveChanges() > 0;
    }

    public bool Update(User user)
    {
        _context.Users.Update(user);
        return _context.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        return _context.SaveChanges() > 0;
    }

    public User GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public List<User> GetUsersBornBefore(DateTime date)
    {
        return _context.Users.Where(u => u.BirthDate < date).ToList();
    }
}
