// ignore_for_file: body_might_complete_normally_nullable

import 'package:bbc_bartender_mobile/blocs/login/login_bloc.dart';
import 'package:bbc_bartender_mobile/blocs/test/test_bloc.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/repositories/user_repo.dart';
import 'package:bbc_bartender_mobile/ui/screens/home_screen.dart';
import 'package:bbc_bartender_mobile/ui/screens/login_screen.dart';
import 'package:bbc_bartender_mobile/ui/screens/splash_screen.dart';
import 'package:bbc_bartender_mobile/ui/screens/test_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RouteName {
  static const String test = '/test';
  static const String splash = '/splash';
  static const String login = '/login';
  static const String home = '/home';
}

class Routes {
  static Route? onGenerateRoute(RouteSettings settings) {
    switch (settings.name) {
      case RouteName.test:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => TestBloc(),
            child: const TestScreen(),
          ),
        );

      case RouteName.splash:
        return MaterialPageRoute(
          builder: (context) => RepositoryProvider(
            create: (_) => UserRepo(),
            child: const SplashScreen(),
          ),
        );

      case RouteName.login:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => LoginBloc(),
            child: LoginScreen(),
          ),
        );

      case RouteName.home:
        return MaterialPageRoute(
          builder: (context) => MultiRepositoryProvider(
            providers: [
              RepositoryProvider<ItemRepo>(
                create: (context) => ItemRepo(),
              ),
              RepositoryProvider<OrderRepo>(
                create: (context) => OrderRepo(),
              ),
            ],
            child: const HomeScreen(),
          ),
        );
      default:
        return null;
    }
  }
}
