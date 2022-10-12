import 'package:bbc_bartender_mobile/blocs/splash/splash_bloc.dart';
import 'package:bbc_bartender_mobile/repositories/user_repo.dart';
import 'package:bbc_bartender_mobile/routes.dart';
import 'package:bbc_bartender_mobile/ui/widgets/loader.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => SplashBloc(
        RepositoryProvider.of<UserRepo>(context),
      )..add(CheckLoginEvent()),
      child: BlocListener<SplashBloc, SplashState>(
        listener: (context, state) {
          if (state is LoginSuccessState) {
            Navigator.pushNamed(context, RouteName.Home);
          } else if (state is LoginFailState) {
            Navigator.pushNamed(context, RouteName.Login);
          }
        },
        child: Container(
          color: MColor.white,
          child: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                // Text(AppInfo.Name),
                Loader(),
              ],
            ),
          ),
        ),
      ),
    );
  }
}