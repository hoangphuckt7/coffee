import 'package:bartender_app/blocs/splash/splash_bloc.dart';
import 'package:bartender_app/repositories/user_repo.dart';
import 'package:bartender_app/routes.dart';
import 'package:bartender_app/ui/widgets/loader.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter/material.dart';

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocListener<SplashBloc, SplashState>(
      listener: (context, state) {
        if (state is LoginSuccessState) {
          Navigator.pushNamed(context, RouteName.home);
        } else if (state is LoginFailState) {
          Navigator.pushNamed(context, RouteName.login);
        }
      },
      child: Container(
        color: MColor.white,
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: const [
              // Text(AppInfo.Name),
              Loader(),
            ],
          ),
        ),
      ),
    );
  }
}
