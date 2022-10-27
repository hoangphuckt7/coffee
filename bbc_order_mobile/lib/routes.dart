// ignore_for_file: body_might_complete_normally_nullable

import 'package:bbc_order_mobile/blocs/auth/auth_bloc.dart';
import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/blocs/splash/splash_bloc.dart';
import 'package:bbc_order_mobile/blocs/test/test_bloc.dart';
import 'package:bbc_order_mobile/ui/screens/change_table_screen.dart';
import 'package:bbc_order_mobile/ui/screens/check_out_screen.dart';
import 'package:bbc_order_mobile/ui/screens/login_screen.dart';
import 'package:bbc_order_mobile/ui/screens/order_screen.dart';
import 'package:bbc_order_mobile/ui/screens/pick_table_screen.dart';
import 'package:bbc_order_mobile/ui/screens/splash_screen.dart';
import 'package:bbc_order_mobile/ui/screens/test_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class RouteName {
  static const String test = '/test';
  static const String splash = '/splash';
  static const String login = '/login';
  static const String pickTable = '/pickTable';
  static const String changeTable = '/changeTable';
  static const String order = '/order';
  static const String checkOut = '/checkOut';
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

      case RouteName.pickTable:
        return MaterialPageRoute(
          builder: (context) => MultiBlocProvider(
            providers: [
              BlocProvider(
                create: (context) => PickTableBloc()..add(LoadDataEvent()),
              ),
              BlocProvider(
                create: (context) => AuthBloc()..add(LoadUserInfoEvent()),
              ),
            ],
            child: PickTableScreen(),
          ),
        );
      case RouteName.changeTable:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => PickTableBloc()..add(LoadDataEvent()),
            child: ChangeTableScreen(),
          ),
        );
      case RouteName.order:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => PickTableBloc()..add(LoadDataEvent()),
            child: OrderScreen(),
          ),
        );
      case RouteName.checkOut:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => PickTableBloc()..add(LoadDataEvent()),
            child: CheckOutScreen(),
          ),
        );
      default:
        return null;
    }
  }
}
