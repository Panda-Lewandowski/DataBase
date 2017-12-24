import pandas


def get():

    raw_data = pandas.read_csv('titanic.csv')
    size = raw_data['PassengerId'].count()

    for i in range(10):
        print('passengers.Add(new Passenger(', raw_data.iloc[i]['PassengerId'], ', "',
              raw_data.iloc[i]['Name'], '", "', raw_data.iloc[i]['Sex'], '", ',
              raw_data.iloc[i]['Age'], ', "', raw_data.iloc[i]['Ticket'], '", ',
              raw_data.iloc[i]['Survived'], '));')


if __name__ == "__main__":
    get()




