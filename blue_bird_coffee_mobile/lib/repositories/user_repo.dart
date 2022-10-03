import 'package:blue_bird_coffee_mobile/api/fetch.dart';

class UserRepo {
  static Stream login({username, password}) async* {
    var resp = await Fetch.post('/login', {username, password});
  }
}
