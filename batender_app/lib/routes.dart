// ignore_for_file: body_might_complete_normally_nullable

import 'package:bartender_app/blocs/home/home_bloc.dart';
import 'package:bartender_app/blocs/auth/auth_bloc.dart';
import 'package:bartender_app/blocs/splash/splash_bloc.dart';
import 'package:bartender_app/blocs/test/test_bloc.dart';
import 'package:bartender_app/blocs/user_info/user_info_bloc.dart';
import 'package:bartender_app/ui/screens/home_screen.dart';
import 'package:bartender_app/ui/screens/login_screen.dart';
import 'package:bartender_app/ui/screens/splash_screen.dart';
import 'package:bartender_app/ui/screens/test_screen.dart';
import 'package:bartender_app/ui/screens/user_info_sceen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RouteName {
  static const String test = '/test';
  static const String splash = '/splash';
  static const String login = '/login';
  static const String home = '/home';
  static const String userInfo = '/userInfo';
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
            create: (_) => SplashBloc()..add(SPCheckLoginEvent()),
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
                  ..add(HomeLoadDataEvent())
                  ..add(HomeListenRecieveNewOrderEvent()),
              ),
              BlocProvider(
                create: (context) => AuthBloc()..add(AuthLoadUserInfoEvent()),
              ),
            ],
            child: const HomeScreen(),
          ),
        );
      case RouteName.userInfo:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => UserInfoBloc()..add(UILoadInfoEvent()),
            child: UserInfoScreen(),
          ),
        );
      default:
        return null;
    }
  }
}
