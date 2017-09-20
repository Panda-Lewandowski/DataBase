import pandas


def format_age(age):
    if pandas.isnull(age):
        return 'Null'
    else:
        return int(round(age))


def format_ticket(ticket):
    ticket = ticket.split(' ')
    if len(ticket) == 1:
        try:
            return int(ticket[0])
        except ValueError:
            return 'Null'
    else:
        try:
            return int(ticket[len(ticket)-1])
        except ValueError:
            return 'Null'


def format_sur(sur):
    if sur:
        return 'True'
    else:
        return 'False'


def generate():
    raw_data = pandas.read_csv('titanic.csv')
    size = raw_data['PassengerId'].count()
    # print(raw_data.head())

    # Generate passengers table as P with PassengerId, Name, Sex, Age
    p = open('p.txt', 'w')
    for i in range(size):
            p.write("{0:<85}    {1:>10}    {2:>4}\n".format(raw_data.iloc[i]['Name'],
                                                            raw_data.iloc[i]['Sex'],
                                                            format_age(raw_data.iloc[i]['Age'])))
    p.close()



    # Generate Parch table as S with PassengerId, Name, Survived
    s = open('s.txt', 'w')
    for i in range(size):
        s.write("{0:>4}    {1:>2}    {2:>2}\n".format(raw_data.iloc[i]['PassengerId'],
                                                      raw_data.iloc[i]['Parch'],
                                                      raw_data.iloc[i]['SibSp']))

    s.close()

    #print(raw_data['Ticket'].value_counts())

    # Generate tickets table as T with Ticket, Name, Fare, Persons, Pclass, Embarked
    t = open('t.txt', 'w')
    for i in range(size):
        uni = raw_data[raw_data.Ticket == raw_data.iloc[i]['Ticket']]
        if raw_data.iloc[i]['Name'] != uni.iloc[0]['Name']:
            continue

        t.write("{0:<10}    {1:<85}    {2:<10}    "
                "{3:>2}    {4:>2}    {5:<2}\n".format(format_ticket(raw_data.iloc[i]['Ticket']),
                                                      uni.iloc[0]['Name'],
                                                      raw_data.iloc[i]['Fare'],
                                                      uni['Name'].count(),
                                                      raw_data.iloc[i]['Pclass'],
                                                      raw_data.iloc[i]['Embarked']))

    t.close()

    # Generate Survival table as PTS with PassengerId, Name, Pclass
    pts = open('pts.txt', 'w')
    for i in range(size):
        pts.write("{0:>4}    {1:<85}    {2:<10}    {3:<5}\n".format(raw_data.iloc[i]['PassengerId'],
                                                                    raw_data.iloc[i]['Name'],
                                                                    format_ticket(raw_data.iloc[i]['Ticket']),
                                                                    format_sur(raw_data.iloc[i]['Survived'])))

    pts.close()


if __name__ == "__main__":
    generate()
