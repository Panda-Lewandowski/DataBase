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
        return 'TRUE'
    else:
        return 'FALSE'


def generate():
    raw_data = pandas.read_csv('titanic.csv')
    size = raw_data['PassengerId'].count()
    # print(raw_data.head())

    # Generate passengers table as P with PassengerId, Name, Sex, Age
    p = open('p.csv', 'w')
    p.write("Name,Sex,Age\n")
    for i in range(size):
        string_to_write = "{0},{1},{2}\n".format(raw_data.iloc[i]['Name'],
                                                 raw_data.iloc[i]['Sex'],
                                                 format_age(raw_data.iloc[i]['Age']))
        string_to_write = string_to_write.replace(", ", " ")
        string_to_write = string_to_write.replace("Null", "")
        p.write(string_to_write)
    p.close()

    # Generate Parch table as S with PassengerId, Name, Survived
    s = open('s.csv', 'w')
    s.write("PassengerId,Parch,SibSp\n")
    for i in range(size):
        string_to_write = "{0},{1},{2}\n".format(raw_data.iloc[i]['PassengerId'],
                                                 raw_data.iloc[i]['Parch'],
                                                 raw_data.iloc[i]['SibSp'])
        string_to_write = string_to_write.replace("Null", "")
        s.write(string_to_write)
    s.close()

    # Generate tickets table as T with Ticket, Name, Fare, Persons, Pclass, Embarked
    t = open('t.csv', 'w')
    t.write("Ticket,Name,Fare,Persons, Pclass,Embarked\n")
    for i in range(size):
        uni = raw_data[raw_data.Ticket == raw_data.iloc[i]['Ticket']]
        if raw_data.iloc[i]['Name'] != uni.iloc[0]['Name']:
            continue

        string_to_write = "{0},{1},{2},{3},{4},{5}\n".format(format_ticket(raw_data.iloc[i]['Ticket']),
                                                             uni.iloc[0]['Name'],
                                                             raw_data.iloc[i]['Fare'],
                                                             uni['Name'].count(),
                                                             raw_data.iloc[i]['Pclass'],
                                                             raw_data.iloc[i]['Embarked'])
        string_to_write = string_to_write.replace(", ", " ")
        string_to_write = string_to_write.replace("Null", "123456")  # DEFAULT TICKET
        string_to_write = string_to_write.replace("nan", "")
        t.write(string_to_write)
    t.close()

    # Generate Survival table as PTS with PassengerId, Name, Ticket, Survived
    pts = open('pts.csv', 'w')
    pts.write("PassengerId,Name,Ticket,Survived\n")
    for i in range(size):
        string_to_write = "{0},{1},{2},{3}\n".format(raw_data.iloc[i]['PassengerId'],
                                                     raw_data.iloc[i]['Name'],
                                                     format_ticket(raw_data.iloc[i]['Ticket']),
                                                     raw_data.iloc[i]['Survived'])1 
        string_to_write = string_to_write.replace(", ", " ")
        string_to_write = string_to_write.replace("Null", "123456")  # DEFAULT TICKET
        pts.write(string_to_write)
    pts.close()


if __name__ == "__main__":
    generate()
