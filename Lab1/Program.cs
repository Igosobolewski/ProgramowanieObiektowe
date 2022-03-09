using System;

namespace lab1
{
    class Program6
    {
        static void Main(string[] args)
        {
            Person person = Person.Of("");

            Console.WriteLine(person);

            DateTime dateTime = DateTime.Parse("03-02-2022");
            Console.WriteLine(dateTime);

            DateTime newDate = dateTime.AddDays(2);
            Console.WriteLine(newDate + " " + dateTime);
            //6 = 2 + 4
            Money money = Money.Of(10, Currency.PLN);
            string name = "adam";
            string name1 = "adam";
            string v = name.Substring(0, 2);
            Console.WriteLine(name1 == name);
            Money result = money * 5;
            Console.WriteLine(result.Value);
            Money result1 = 5.2m * money;
            Console.WriteLine(result.Value);

            Money sum = money + result;
            Console.WriteLine(sum.Value);

            Console.WriteLine(sum < money);
            Console.WriteLine(money == Money.Of(10, Currency.PLN));

            Console.WriteLine(money != Money.Of(10, Currency.PLN));

            long a = 10L;
            a = 100000000000L;
            int b = 5;
            a = b;
            b = (int)a;

            decimal amount = money;
            float price = (float)money;
            double cost = (double)money;

            Console.WriteLine(amount);
            Console.WriteLine(cost);
            Console.WriteLine(price);

            Console.WriteLine(money);

            Console.WriteLine("To string");
            Console.WriteLine(money.ToString());

            money.Equals(person);

            Money[] prices =
            {
                Money.Of(12, Currency.PLN),
                Money.Of(14, Currency.PLN),
                Money.Of(15, Currency.PLN),
                Money.Of(17, Currency.USD),
                Money.Of(15, Currency.EUR),
                Money.Of(13, Currency.USD)
            };

            Array.Sort(prices);
            foreach (var m in prices)
            {
                Console.WriteLine(m.ToString());
            }

        }

        class Person
        {

            private Person(string name)
            {
                _Name = name;
            }

            public static Person Of(string name)
            {

                if (name != null && name.Length >= 2)
                {
                    return new Person(name);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię zbyt krótkie!");
                }

            }

            private string _Name;
            public string Name
            {
                get
                {
                    return _Name;
                }

                set
                {
                    if (value != null && value.Length >= 2)
                    {
                        _Name = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Imię zbyt krótkie !");
                    }
                }
            }
        }

      

        public enum Currency
        {
            PLN = 1,
            USD = 2,
            EUR = 3
        }

        public class Money: IEquatable<Money>, IComparable<Money>
        {
            private readonly decimal _value;
            private readonly Currency _currency;
            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }

            public decimal Value
            {
                get
                {
                    return _value;
                }
            }

            public Currency Currency
            {
                get
                {
                    return _currency;
                }
            }

            public static Money? Of(decimal value, Currency currency)
            {
                return value < 0 ? null : new Money(value, currency);
            }

            public static Money operator *(Money a, decimal b)
            {
                return Money.Of(a._value * b, a._currency);
            }

            public static Money operator *(decimal b, Money a)
            {
                return Money.Of(a._value * b, a._currency);
            }

            public static Money operator +(Money b, Money a)
            {
                if (a.Currency != b.Currency)
                {
                    throw new ArgumentException("Different Currencies");
                }
                return Money.Of(a._value + b._value, a._currency);
            }


            public static bool operator >(Money a, Money b)
            {
                return a.Value > b.Value;
            }

            public static bool operator <(Money a, Money b)
            {
               
                return a.Value > b.Value;
            }

            public static bool operator ==(Money a, Money b)
            {
                
                return a.Value == b.Value && a.Currency == b.Currency;
            }

            public static bool operator !=(Money a, Money b)
            {
                return a.Value != b.Value && a.Currency != b.Currency;

            }

            public static implicit operator decimal(Money money)
            {
                return money.Value;
            }
            public static explicit operator double(Money money)
            {
                return (double)money.Value;
            }

            public override string ToString()
            {
                return $"Value: {_value}, $Currency: {_currency}";
            }

            public override bool Equals(object obj)
            {
                return obj is Money money &&
                       _value == money._value &&
                       _currency == money._currency;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(_value, _currency);
            }

            public bool Equals(Money other)
            {
                        return
                      _value == other._value &&
                      _currency == other._currency;
            }

            public int CompareTo(Money other)
            {
                int result =  _currency.CompareTo(other._currency);
                if(result == 0){
                    return _value.CompareTo(other._value);
                }else {
                       return result
                      }
            }
        }

    }
}
