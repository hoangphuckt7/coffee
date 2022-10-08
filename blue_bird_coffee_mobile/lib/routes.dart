// ignore_for_file: body_might_complete_normally_nullable

import 'package:blue_bird_coffee_mobile/blocs/home/home_bloc.dart';
import 'package:blue_bird_coffee_mobile/blocs/login/login_bloc.dart';
import 'package:blue_bird_coffee_mobile/repositories/category_repo.dart';
import 'package:blue_bird_coffee_mobile/ui/screens/home_screen.dart';
import 'package:blue_bird_coffee_mobile/ui/screens/login_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RouteName {
  static const String Login = '/login';
  static const String Home = '/home';
}

class Routes {
  static Route? onGenerateRoute(RouteSettings settings) {
    switch (settings.name) {
      case RouteName.Login:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => LoginBloc(),
            child: LoginScreen(),
          ),
        );

      case RouteName.Home:
        return MaterialPageRoute(
          builder: (context) => RepositoryProvider(
            create: (_) => CategoryRepo(),
            child: HomeScreen(),
          ),
        );

      default:
        return null;
    }
  }
}
