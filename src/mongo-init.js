print('Start creating database ##########################')
db.auth('admin-user', 'admin-pass')
db = db.getSiblingDB('eventdb');
db.createUser({
    user: 'sean',
    pwd: 'password',
    roles: [
        {
            role: 'root',
            db: 'eventdb',
        },
    ],
});
print('End creating database ##########################')
