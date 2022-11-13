// ignore_for_file: body_might_complete_normally_nullable, unused_local_variable, prefer_const_constructors

import 'package:orderr_app/blocs/auth/auth_bloc.dart';
import 'package:orderr_app/blocs/change_table/change_table_bloc.dart';
import 'package:orderr_app/blocs/checkout/checkout_bloc.dart';
import 'package:orderr_app/blocs/order/order_bloc.dart';
import 'package:orderr_app/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:orderr_app/blocs/splash/splash_bloc.dart';
import 'package:orderr_app/blocs/test/test_bloc.dart';
import 'package:orderr_app/blocs/user_info/user_info_bloc.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/ui/screens/change_table_screen.dart';
import 'package:orderr_app/ui/screens/checkout_screen.dart';
import 'package:orderr_app/ui/screens/login_screen.dart';
import 'package:orderr_app/ui/screens/order_screen.dart';
import 'package:orderr_app/ui/screens/pick_table_screen.dart';
import 'package:orderr_app/ui/screens/splash_screen.dart';
import 'package:orderr_app/ui/screens/test_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:orderr_app/ui/screens/user_info_sceen.dart';

class RouteName {
  static const String test = '/test';
  static const String splash = '/splash';
  static const String login = '/login';
  static const String pickTable = '/pickTable';
  static const String changeTable = '/changeTable';
  static const String order = '/order';
  static const String checkOut = '/checkOut';
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
      case RouteName.changeTable:
        OrderCreateModel? order;
        if (settings.arguments != null) {
          var lstArg = settings.arguments! as List;
          order = lstArg.isNotEmpty ? lstArg[0] as OrderCreateModel? : null;
        }
        return MaterialPageRoute(
          builder: (context) => MultiBlocProvider(
            providers: [
              BlocProvider(
                create: (context) => AuthBloc()..add(AuthLoadUserInfoEvent()),
              ),
              BlocProvider(
                create: (context) =>
                    ChangeTableBloc()..add(CTLoadFloorTableEvent()),
              ),
            ],
            child: ChangeTableScreen(order: order),
          ),
        );
      case RouteName.pickTable:
        OrderCreateModel? order;
        if (settings.arguments != null) {
          var lstArg = settings.arguments! as List;
          order = lstArg.isNotEmpty ? lstArg[0] as OrderCreateModel? : null;
        }
        return MaterialPageRoute(
          builder: (context) => MultiBlocProvider(
            providers: [
              BlocProvider(
                create: (context) => AuthBloc()..add(AuthLoadUserInfoEvent()),
              ),
              BlocProvider(
                create: (context) =>
                    PickTableBloc()..add(PTLoadFloorTableEvent()),
              ),
            ],
            child: PickTableScreen(order: order),
          ),
        );
      case RouteName.order:
        var lstArg = settings.arguments! as List;
        var order = lstArg[0] as OrderCreateModel;
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => OrderBloc()..add(ORLoadCateItemEvent()),
            child: OrderScreen(order: order),
          ),
        );
      case RouteName.checkOut:
        var lstArg = settings.arguments! as List;
        var order = lstArg[0] as OrderCreateModel;
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => CheckoutBloc(),
            child: CheckOutScreen(order: order),
          ),
        );
      case RouteName.userInfo:
        OrderCreateModel? order;
        if (settings.arguments != null) {
          var lstArg = settings.arguments! as List;
          order = lstArg.isNotEmpty ? lstArg[0] as OrderCreateModel? : null;
        }
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => UserInfoBloc(),
            child: UserInfoScreen(order: order),
          ),
        );
      default:
        return MaterialPageRoute(
          builder: (context) => BlocProvider(
            create: (context) => AuthBloc(),
            child: LoginScreen(),
          ),
        );
    }
  }
}
