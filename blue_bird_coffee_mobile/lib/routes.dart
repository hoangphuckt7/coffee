// ignore_for_file: body_might_complete_normally_nullable

import 'package:blue_bird_coffee_mobile/blocs/home/home_bloc.dart';
import 'package:blue_bird_coffee_mobile/blocs/login/login_bloc.dart';
import 'package:blue_bird_coffee_mobile/blocs/splash/splash_bloc.dart';
import 'package:blue_bird_coffee_mobile/repositories/category_repo.dart';
import 'package:blue_bird_coffee_mobile/repositories/floor_repo.dart';
import 'package:blue_bird_coffee_mobile/repositories/user_repo.dart';
import 'package:blue_bird_coffee_mobile/ui/screens/home_screen.dart';
import 'package:blue_bird_coffee_mobile/ui/screens/login_screen.dart';
import 'package:blue_bird_coffee_mobile/ui/screens/splash_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RouteName {
  static const String Splash = '/splash';
  static const String Login = '/login';
  static const String Home = '/home';
}

class Routes {
  static Route? onGenerateRoute(RouteSettings settings) {
    switch (settings.name) {
      case RouteName.Splash:
        return MaterialPageRoute(
          builder: (context) => RepositoryProvider(
            create: (_) => UserRepo(),
            child: SplashScreen(),
          ),
        );

      case RouteName.Login:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => LoginBloc(),
            child: LoginScreen(),
          ),
        );

      case RouteName.Home:
        return MaterialPageRoute(
          builder: (context) => MultiRepositoryProvider(
            providers: [
              RepositoryProvider<CategoryRepo>(
                create: (context) => CategoryRepo(),
              ),
              RepositoryProvider<FloorRepo>(
                create: (context) => FloorRepo(),
              ),
            ],
            child: HomeScreen(),
          ),
        );

      default:
        return null;
    }
  }
}
