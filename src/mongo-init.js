print('Start creating database ##########################')
//db = db.getSiblingDB('admin');
// move to the admin db - always created in Mongo
db.auth('admin-user', 'admin-pass')
db = db.getSiblingDB('eventdb');
db.createUser({
    user: 'sean',
    pwd: 'password',
    roles: [
        {
            role: 'dbOwner',
            db: 'eventdb',
        },
    ],
});
// db.updateUser("admin",
// {
//     roles : [
//         { role: "dbOwner", db: 'eventDb' }
//       ]
// });
print('End creating database ##########################')
