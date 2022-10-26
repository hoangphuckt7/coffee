// ignore_for_file: body_might_complete_normally_nullable

import 'package:bbc_bartender_mobile/blocs/home/home_bloc.dart';
import 'package:bbc_bartender_mobile/blocs/auth/auth_bloc.dart';
import 'package:bbc_bartender_mobile/blocs/splash/splash_bloc.dart';
import 'package:bbc_bartender_mobile/blocs/test/test_bloc.dart';
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
          builder: (context) => BlocProvider(
            create: (_) => SplashBloc()..add(CheckLoginEvent()),
            child: const SplashScreen(),
          ),
        );

      case RouteName.login:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => AuthBloc(),
            child: LoginScreen(),
          ),
        );

      case RouteName.home:
        return MaterialPageRoute(
          builder: (context) => MultiBlocProvider(
            providers: [
              BlocProvider(
                create: (context) => HomeBloc()
                  ..add(LoadDataEvent())
                  ..add(ListenRecieveNewOrderEvent()),
              ),
              BlocProvider(
                create: (context) => AuthBloc()..add(LoadUserInfoEvent()),
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
